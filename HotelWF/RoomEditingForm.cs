﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelWF.zClasses;

namespace HotelWF
{
    internal partial class RoomEditingForm : Form
    {
        private Room R;
        public RoomEditingForm(Room r0)
        {
            R = r0;
            InitializeComponent();
            display();
        }
        private void display()
        {
            this.typeTextBox.Text = R.getType();
            this.noTextBox.Text = R.getNumber().ToString();
            this.areaTextBox.Text = R.getArea().ToString();
            this.maxGuestsTextBox.Text = R.getMaxGuests().ToString();
            this.guestsTextBox.Text = R.getNumberOfGuests().ToString();
            this.feeTextBox.Text = R.getFee().ToString();
        }
        private void editNumber()
        {
            int  n0 = int.Parse(this.noTextBox.Text);
            R.setNumber(n0);
        }
    }
}
