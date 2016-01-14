using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading;
using EI;
using EF;
namespace MC
{
     class clsReadCardThread
    {
         AxReadCardInfo.AxReadCard _card ;
         EF.EFTextBox    _fnum;
         EF.EFLabelText _fname;
         System.Timers.Timer _timer;
         
        public clsReadCardThread(ref EFTextBox num ,ref EFLabelText name)
        {
            try
            {
               
                _fnum = num;
                _fname = name;
               // _card = f.axReadCard1;
                _timer = new System.Timers.Timer();
                _timer.Interval = 6000;
                _timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
                //card.ComPort = 1;
            }
            catch (Exception ex)
            {
                String exms = ex.Message;
            }
            
        }
        public void start()
        {
            _timer.Start();
        }
        void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //throw new NotImplementedException();
            string empNO = ""; string empName = "";
            int cardId = 0;
            frmReadCard f = new frmReadCard();
            //ReadCardTimer.Enabled = false;
            //RCD_Timer.Enabled = false;
            //RCD_Timer.Stop();
            //while (1 == 1)
            //{
            _timer.Stop();
            _timer.Interval = 5000;
            try
            {
                int retValue = f.axReadCard1.ReadCard(ref empNO, ref empName, ref cardId);

                //if (retValue == -1)
                //{
                //    MessageBox.Show("打开串口错误，未能识别读卡器！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                //else if (retValue == -2)
                //{
                //    MessageBox.Show("卡片信息有误，未能识别卡片信息！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                if (retValue == 0)
                {
                    if (empNO.Length == 13 && _fnum.Text != empNO.Substring(0, 8))
                    {

                        _fnum.Text = empNO; _fname.EFEnterText = empName;
                        _fnum.Refresh(); _fname.Refresh();

                    }
                }
                else
                {
                    //MessageBox.Show("打开串口错误，未能识别读卡器！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //ReadCardTimer.Stop();
                    //return;

                }
            }
            catch (Exception ex)
            {
                String exms = ex.Message;
            }
            _timer.Start();
        }
    }
}
