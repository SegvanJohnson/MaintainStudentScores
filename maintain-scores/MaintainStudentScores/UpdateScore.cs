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
    public partial class frmUpdateScore : Form
    {
        public frmUpdateScore()
        {
            InitializeComponent();
        }

        private void frmUpdateScore_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (Int32.Parse(txtScore.Text) >= 0 && Int32.Parse(txtScore.Text) <= 100)
                {
                    frmUpdateStudentScores.tmpStudents.Values.ElementAt(frmStudentScores.selected)[frmUpdateStudentScores.selected]
                            = Int32.Parse(txtScore.Text);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please enter a score between 0 and 100.", "Invalid score");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number", "Invalid Entry");
            }
        }
    }
}
