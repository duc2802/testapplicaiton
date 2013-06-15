﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PresentationLayer.QuestionEditor
{
    public partial class AnswerItem : UserControl
    {
        public static int WIDTH = 237;
        public static int HEIGHT = 47;
        public AnswerItem()
        {
            InitializeComponent();

        }
        public AnswerItem(String idAnswer, String result, String answerContent)
        {
            InitializeComponent();
            InitGui(idAnswer,result,answerContent);
        }
        private void InitGui(String idAnswer, String result, String answerContent)
        {
            this.lbAnswer.Text = idAnswer;
            this.lbResultAnswer.Text = result;
            this.lbContentAnswer.Text = answerContent;
        }
       
    }
}