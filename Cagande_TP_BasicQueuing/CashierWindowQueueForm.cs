using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cagande_TP_BasicQueuing
{
    public partial class CashierWindowQueueForm : Form
    {
        private CustomerView CView;
        private Timer timer;
        public CashierWindowQueueForm()
        {
            InitializeComponent();
            InitializeTimer();


            Timer timer = new Timer();
            timer.Interval = (1 * 1000);
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();

            CView = new CustomerView();
            CView.Show();
        }
        private void InitializeTimer()
        {
            Timer timer = new Timer();
            timer.Interval = (1 * 1000);
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            RemoveCompletedItems();
            DisplayCashierQueue(CashierClass.CashierQueue);
        }

        private void RemoveCompletedItems()
        {
            if (CashierClass.CashierQueue.Count > 0)
            {
                CashierClass.CashierQueue.Dequeue(); //Remove the first item in the queue.
            }
        }

        public void DisplayCashierQueue(IEnumerable CashierList)
        {
            listCashierQueue.Items.Clear();
            foreach (object obj in CashierList)
            {
                listCashierQueue.Items.Add(obj.ToString());
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DisplayCashierQueue(CashierClass.CashierQueue);
        }

        
        private void timer1_Tick(object sender, EventArgs e)
        {
            DisplayCashierQueue(CashierClass.CashierQueue);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (CashierClass.CashierQueue.Count != null && CashierClass.CashierQueue.Count > 0)
            {
                if (CashierClass.CashierQueue.Contains(CashierClass.CashierQueue.Peek()))
                {
                    string s = CashierClass.CashierQueue.Peek();
                }
                CashierClass.CashierQueue.Dequeue();
            }
            else
            {
                MessageBox.Show("The queue is empty.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
