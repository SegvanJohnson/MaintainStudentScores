﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaintainStudentScores
{
    public partial class frmUpdateStudentScores : Form
    {
        public static Dictionary<string, List<int>> tmpStudents;
        BindingSource bs = new BindingSource();
        public static int selected;

        public frmUpdateStudentScores()
        {
            InitializeComponent();
        }

        private void frmUpdateStudentScores_Activated(object sender, EventArgs e)
        {
            txtName.Text = tmpStudents.Keys.ElementAt(frmStudentScores.selected);
            bs.DataSource = tmpStudents.Values.ElementAt(frmStudentScores.selected);
            lbxScores.DataSource = bs;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form addScore = new frmAddScore();
            addScore.ShowDialog();
            bs.ResetBindings(false);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            frmStudentScores.students = tmpStudents;
            this.Close();            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            selected = lbxScores.SelectedIndex;
            Form updateScore = new frmUpdateScore();
            updateScore.ShowDialog();
            bs.ResetBindings(false);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            tmpStudents.Values.ElementAt(frmStudentScores.selected).RemoveAt(lbxScores.SelectedIndex);
            bs.ResetBindings(false);
        }

        private void frmUpdateStudentScores_Load(object sender, EventArgs e)
        {
            tmpStudents = frmStudentScores.students.ToDictionary(p => p.Key, p => p.Value.ToList());
        }

        private void btnClearScores_Click(object sender, EventArgs e)
        {
            tmpStudents.Values.ElementAt(frmStudentScores.selected).RemoveRange(
                0, tmpStudents.Values.ElementAt(frmStudentScores.selected).Count);
            bs.ResetBindings(false);
        }
    }
}
