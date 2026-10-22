using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsHW3
{
    public partial class Form1 : Form
    {
        SaveLoad infoManipulation;

        bool isInfoAdded = false;
        bool btnAddTestPressed = false;
        bool btnEditTestPressed = false;
        bool btnEditQQPressed = false;
        bool btnEditAnsPressed = false;
        bool isControlsDis = false;

        public Form1()
        {
            InitializeComponent();

            ToolTip toolTip = new ToolTip();
            toolTip.InitialDelay = 500;
            toolTip.ToolTipIcon = ToolTipIcon.Info;
            toolTip.SetToolTip(txBoxQQ, "Ввод названия вопроса");
            toolTip.SetToolTip(txBoxAns, "Ввод ответа");
            toolTip.SetToolTip(chBoxTrueAns, "Является ли ответ верным");

            numMark.Enabled = false;
            numMinutes.Enabled = false;

            #region BtnsColor
            btnTestAdd.MouseEnter += btnsMouseEnter;
            btnTestAdd.MouseLeave += btnsMouseLeave;
            btnTestEdit.MouseEnter += btnsMouseEnter;
            btnTestEdit.MouseLeave += btnsMouseLeave;
            btnTestDel.MouseEnter += btnsMouseEnter;
            btnTestDel.MouseLeave += btnsMouseLeave;
            btnQQAdd.MouseEnter += btnsMouseEnter;
            btnQQAdd.MouseLeave += btnsMouseLeave;
            btnQQEd.MouseEnter += btnsMouseEnter;
            btnQQEd.MouseLeave += btnsMouseLeave;
            btnQQDel.MouseEnter += btnsMouseEnter;
            btnQQDel.MouseLeave += btnsMouseLeave;
            btnAnsAdd.MouseEnter += btnsMouseEnter;
            btnAnsAdd.MouseLeave += btnsMouseLeave; 
            btnAnsEd.MouseEnter += btnsMouseEnter;
            btnAnsEd.MouseLeave += btnsMouseLeave;
            btnAnsDel.MouseEnter += btnsMouseEnter;
            btnAnsDel.MouseLeave += btnsMouseLeave;
            btnSave.MouseEnter += btnsMouseEnter;
            btnSave.MouseLeave += btnsMouseLeave;
            #endregion
        }
        private void OffOnControl()
        {
            btnAnsAdd.Enabled = !btnAnsAdd.Enabled;
            btnAnsDel.Enabled = !btnAnsDel.Enabled;
            btnAnsEd.Enabled = !btnAnsEd.Enabled;
            btnQQAdd.Enabled = !btnQQAdd.Enabled;
            btnQQDel.Enabled = !btnQQDel.Enabled;
            btnQQEd.Enabled = !btnQQEd.Enabled;
            btnTestEdit.Enabled = !btnTestEdit.Enabled;
            btnTestDel.Enabled = !btnTestDel.Enabled;
            btnSave.Enabled = !btnSave.Enabled;
            chBoxTrueAns.Enabled = !chBoxTrueAns.Enabled;
            isControlsDis = !isControlsDis;
        }
        private void ClearControlsTexts()
        {
            txBoxNameHided.Text = null;
            numMark.Value = 0;
            numMinutes.Value = 0;
            lstBoxAns.Items.Clear();
            lstBoxQQ.Items.Clear();
            chBoxTrueAns.Checked = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            infoManipulation = new SaveLoad();
            infoManipulation.LoadFromFile();
            if (infoManipulation.info.tests.Count != 0)
            {
                foreach (var n in infoManipulation.info.tests)
                {
                    cmBoxName.Items.Add(n.Name);
                }
                isInfoAdded = true;
            }
            else
            {
                OffOnControl();
            }
        }

        private void btnTestAdd_Click(object sender, EventArgs e)
        {
            if (!btnAddTestPressed)
            {
                if (cmBoxName.SelectedItem != null)
                {
                    OffOnControl();
                    ClearControlsTexts();
                }
                btnTestAdd.Text = "Подтвердить";
                btnAddTestPressed = !btnAddTestPressed;
                cmBoxName.Visible = !cmBoxName.Visible;
                txBoxNameHided.Visible = !txBoxNameHided.Visible;
                numMinutes.Enabled = !numMinutes.Enabled;
                numMark.Enabled = !numMark.Enabled;
                btnTestEdit.Enabled = !btnTestEdit.Enabled;
                btnTestDel.Enabled = !btnTestDel.Enabled;
                if(!isInfoAdded)
                {
                    btnTestEdit.Enabled = !btnTestEdit.Enabled;
                    btnTestDel.Enabled = !btnTestDel.Enabled;
                }
            }
            else
            {
                if (cmBoxName.Text != null && numMark.Value != 0 && numMinutes.Value != 0)
                {
                    infoManipulation.AddTest(txBoxNameHided.Text, numMinutes.Value, numMark.Value);
                    infoManipulation.selectedIdx = cmBoxName.Items.Count;
                    cmBoxName.Items.Add(infoManipulation.GetTestName(infoManipulation.selectedIdx));
                    if (!isInfoAdded)
                    {
                        OffOnControl();
                        btnTestEdit.Enabled = !btnTestEdit.Enabled;
                        btnTestDel.Enabled = !btnTestDel.Enabled;
                    }
                    if (isControlsDis)
                        OffOnControl();
                    btnTestAdd.Text = "Добавить новый тест";
                    btnAddTestPressed = !btnAddTestPressed;
                    cmBoxName.Visible = !cmBoxName.Visible;
                    txBoxNameHided.Visible = !txBoxNameHided.Visible;
                    cmBoxName.SelectedIndex = cmBoxName.Items.Count - 1;
                    numMinutes.Enabled = !numMinutes.Enabled;
                    numMark.Enabled = !numMark.Enabled;
                    btnTestEdit.Enabled = !btnTestEdit.Enabled;
                    btnTestDel.Enabled = !btnTestDel.Enabled;
                }
                else MessageBox.Show("Не все параметры заполнены", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cmBoxName_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstBoxQQ.Items.Clear();
            lstBoxAns.Items.Clear();
            chBoxTrueAns.Checked = false;
            infoManipulation.selectedIdx = cmBoxName.SelectedIndex;
            numMinutes.Value = infoManipulation.info.tests.ElementAt(infoManipulation.selectedIdx).MaxTime;
            numMark.Value = infoManipulation.info.tests.ElementAt(infoManipulation.selectedIdx).MaxMark;

            if (infoManipulation.info.tests.ElementAt(cmBoxName.SelectedIndex).questions.Count != 0)
            {
                foreach (var n in infoManipulation.info.tests.ElementAt(infoManipulation.selectedIdx).questions)
                    lstBoxQQ.Items.Add(n.Question);
                lstBoxQQ.SelectedIndex = 0;
            }
        }

        private void btnTestEdit_Click(object sender, EventArgs e)
        {
            if (cmBoxName.SelectedIndex == -1)
            {
                MessageBox.Show("Тест не выбран", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (!btnEditTestPressed)
                {
                    if (isControlsDis)
                        OffOnControl();
                    btnTestEdit.Text = "Подтвердить";
                    numMinutes.Enabled = !numMinutes.Enabled;
                    numMark.Enabled = !numMark.Enabled;
                    btnEditTestPressed = !btnEditTestPressed;
                    cmBoxName.Visible = !cmBoxName.Visible;
                    txBoxNameHided.Visible = !txBoxNameHided.Visible;
                    txBoxNameHided.Text = cmBoxName.Text;
                    btnTestAdd.Enabled = !btnTestAdd.Enabled;
                    btnTestDel.Enabled = !btnTestDel.Enabled;
                }
                else
                {
                    DialogResult res = MessageBox.Show("Изменить данные теста?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        infoManipulation.EditTest(txBoxNameHided.Text, numMinutes.Value, numMark.Value);
                        int idx = cmBoxName.SelectedIndex;
                        cmBoxName.Items.RemoveAt(cmBoxName.SelectedIndex);
                        cmBoxName.Items.Insert(idx, txBoxNameHided.Text);
                        btnTestEdit.Text = "Изменить тест";
                        numMinutes.Enabled = !numMinutes.Enabled;
                        numMark.Enabled = !numMark.Enabled;
                        btnEditTestPressed = !btnEditTestPressed;
                        cmBoxName.Visible = !cmBoxName.Visible;
                        txBoxNameHided.Visible = !txBoxNameHided.Visible;
                        cmBoxName.SelectedIndex = idx;
                        btnTestAdd.Enabled = !btnTestAdd.Enabled;
                        btnTestDel.Enabled = !btnTestDel.Enabled;
                    }
                }
            }
        }

        private void btnTestDel_Click(object sender, EventArgs e)
        {
            if (cmBoxName.SelectedIndex == -1)
            {
                MessageBox.Show("Тест не выбран", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult res = MessageBox.Show("Удалить тест?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    cmBoxName.Items.Remove(cmBoxName.SelectedItem);
                    cmBoxName.Text = null;
                    ClearControlsTexts();
                    infoManipulation.DeleteTest();
                }
                res = MessageBox.Show("Сохранить изменения в файл?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                    infoManipulation.SaveToFile();
            }
        }

        private void lstBoxQQ_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstBoxAns.Items.Clear();
            if (lstBoxQQ.SelectedIndex != -1)
                if (infoManipulation.info.tests.ElementAt(infoManipulation.selectedIdx).questions.ElementAt(lstBoxQQ.SelectedIndex).answers.Count != 0)
                {
                    foreach (var n in infoManipulation.info.tests.ElementAt(infoManipulation.selectedIdx).questions.ElementAt(lstBoxQQ.SelectedIndex).answers)
                        lstBoxAns.Items.Add(n.Answer);
                    lstBoxAns.SelectedIndex = 0;
                }
        }

        private void btnQQAdd_Click(object sender, EventArgs e)
        {
            if (cmBoxName.SelectedIndex == -1)
                MessageBox.Show("Не выбран тест", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (txBoxQQ.Text == null || txBoxQQ.Text == "")
                MessageBox.Show("Не введен вопрос", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                infoManipulation.AddTestQuestion(txBoxQQ.Text);
                lstBoxQQ.Items.Add(txBoxQQ.Text);
                lstBoxQQ.SelectedIndex = lstBoxQQ.Items.Count - 1;
                txBoxQQ.Text = null;
            }
        }

        private void btnQQEd_Click(object sender, EventArgs e)
        {
            if (cmBoxName.SelectedIndex == -1)
                MessageBox.Show("Не выбран тест", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (lstBoxQQ.SelectedIndex == -1)
                MessageBox.Show("Не выбран вопрос", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (!btnEditQQPressed)
                {
                    btnQQAdd.Enabled = !btnQQAdd.Enabled;
                    btnQQDel.Enabled = !btnQQDel.Enabled;
                    btnQQEd.Text = "Подтвердить";
                    txBoxQQ.Text = lstBoxQQ.SelectedItem.ToString();
                    btnEditQQPressed = !btnEditQQPressed;
                }
                else
                {
                    infoManipulation.EditTestQuestion(lstBoxQQ.SelectedItem.ToString(), txBoxQQ.Text);
                    btnQQEd.Text = "Изменить";
                    int idx = lstBoxQQ.SelectedIndex;
                    lstBoxQQ.SelectedIndex = -1;
                    lstBoxQQ.Items.RemoveAt(idx);
                    lstBoxQQ.Items.Insert(idx, txBoxQQ.Text);
                    btnQQAdd.Enabled = !btnQQAdd.Enabled;
                    btnQQDel.Enabled = !btnQQDel.Enabled;
                    txBoxQQ.Text = null;
                    btnEditQQPressed = !btnEditQQPressed;
                    lstBoxQQ.SelectedIndex = idx;
                }
            }
        }

        private void btnQQDel_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Подтвердите удаление", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                infoManipulation.DeleteTestQuestion(lstBoxQQ.SelectedItem.ToString());
                int idx = lstBoxQQ.SelectedIndex;
                lstBoxQQ.SelectedIndex = -1;
                lstBoxQQ.Items.RemoveAt(idx);
                lstBoxAns.Items.Clear();
            }
        }

        private void lstBoxAns_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBoxAns.SelectedIndex != -1)
                chBoxTrueAns.Checked = infoManipulation.info.tests.ElementAt(infoManipulation.selectedIdx).questions.ElementAt(lstBoxQQ.SelectedIndex).answers.ElementAt(lstBoxAns.SelectedIndex).isTrue;
            if (lstBoxAns.SelectedIndex == -1)
                chBoxTrueAns.Checked = false;
        }

        private void btnAnsAdd_Click(object sender, EventArgs e)
        {
            if (cmBoxName.SelectedIndex == -1)
                MessageBox.Show("Не выбран тест", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (lstBoxQQ.SelectedIndex == -1)
                MessageBox.Show("Не выбран вопрос", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (txBoxAns.Text == "" || txBoxAns.Text == null)
                MessageBox.Show("Не введен ответ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                infoManipulation.AddTestQuestionAnswer(lstBoxQQ.SelectedIndex, txBoxAns.Text, chBoxTrueAns.Checked);
                lstBoxAns.Items.Add(txBoxAns.Text);
                lstBoxAns.SelectedIndex = lstBoxAns.Items.Count - 1;
                txBoxAns.Text = null;
                chBoxTrueAns.Checked = false;
            }
        }

        private void btnAnsEd_Click(object sender, EventArgs e)
        {
            if (cmBoxName.SelectedIndex == -1)
                MessageBox.Show("Не выбран тест", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (lstBoxQQ.SelectedIndex == -1)
                MessageBox.Show("Не выбран вопрос", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (lstBoxAns.SelectedIndex == -1)
                MessageBox.Show("Не выбран ответ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (!btnEditAnsPressed)
                {
                    btnAnsAdd.Enabled = !btnAnsAdd.Enabled;
                    btnAnsDel.Enabled = !btnAnsDel.Enabled;
                    btnAnsEd.Text = "Подтвердить";
                    txBoxAns.Text = lstBoxAns.SelectedItem.ToString();
                    btnEditAnsPressed = !btnEditAnsPressed;
                }
                else
                {
                    infoManipulation.EditTestQuestionAnswer(lstBoxQQ.SelectedIndex, lstBoxAns.SelectedIndex, txBoxAns.Text, chBoxTrueAns.Checked);
                    btnQQEd.Text = "Изменить";
                    int idx = lstBoxAns.SelectedIndex;
                    lstBoxAns.SelectedIndex = -1;
                    lstBoxAns.Items.RemoveAt(idx);
                    lstBoxAns.Items.Insert(idx, txBoxAns.Text);
                    btnAnsAdd.Enabled = !btnAnsAdd.Enabled;
                    btnAnsDel.Enabled = !btnAnsDel.Enabled;
                    txBoxAns.Text = null;
                    btnEditAnsPressed = !btnEditAnsPressed;
                    lstBoxAns.SelectedIndex = idx;
                }
            }
        }

        private void btnAnsDel_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Подтвердите удаление", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                infoManipulation.DeleteTestQuestionAnswer(lstBoxQQ.SelectedIndex, lstBoxAns.SelectedIndex);
                int idx = lstBoxAns.SelectedIndex;
                lstBoxAns.SelectedIndex = -1;
                lstBoxAns.Items.RemoveAt(idx);
                chBoxTrueAns.Checked = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            infoManipulation.SaveToFile();
            MessageBox.Show("Done", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnsMouseEnter(object sender, EventArgs e)
           => (sender as Button).BackColor = Color.FromName("GradientActiveCaption");
        private void btnsMouseLeave(object sender, EventArgs e)
            => (sender as Button).BackColor = Color.FromName("GradientInactiveCaption");
    }
}