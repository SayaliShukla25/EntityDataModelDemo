using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityDataModelDemo
{
    public partial class Form2 : Form
    {
        ProductEntities dbcontext = new ProductEntities();
        public Form2()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                Product prod = new Product();
                prod.Name = txtProductName.Text;
                prod.Price = Convert.ToInt32(txtPrice.Text);
                dbcontext.Products.Add(prod);
                dbcontext.SaveChanges();
                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Product prod = dbcontext.Products.Find(Convert.ToInt32(txtProductId.Text));
                if (prod != null)
                {
                    txtProductName.Text = prod.Name;
                    txtPrice.Text = prod.Price.ToString();
                }
                else
                {
                    MessageBox.Show("Record not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Product prod = dbcontext.Products.Find(Convert.ToInt32(txtProductId.Text));
                if (prod != null)
                {
                    prod.Name = txtProductName.Text;
                    prod.Price = Convert.ToInt32(txtPrice.Text);
                    dbcontext.SaveChanges();
                    MessageBox.Show("updated");
                }
                else
                {
                    MessageBox.Show("Record not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Product prod = dbcontext.Products.Find(Convert.ToInt32(txtProductId.Text));
                if (prod != null)
                {
                    dbcontext.Products.Remove(prod);
                    dbcontext.SaveChanges();
                    MessageBox.Show("deleted");
                }
                else
                {
                    MessageBox.Show("Record not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnShowAllProducts_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dbcontext.Products.ToList();
        }
    }
    }

