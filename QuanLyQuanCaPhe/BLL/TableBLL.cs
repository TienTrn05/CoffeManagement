using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace QuanLyQuanCaPhe.BLL
{
    public class TableBLL
    {
        private static TableBLL _instance;
        private readonly CoffeeManagementEntities1 _context;

        private TableBLL()
        {
            _context = new CoffeeManagementEntities1();
        }

        public static TableBLL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TableBLL();
                return _instance;
            }
        }

       

        public void SwitchTable(int idTable1, int idTable2)
        {
            var firstBill = _context.Bills.FirstOrDefault(b => b.IdTable == idTable1 && !b.StatusBill);
            var secondBill = _context.Bills.FirstOrDefault(b => b.IdTable == idTable2 && !b.StatusBill);

            if (firstBill == null)
            {
                firstBill = new Bill
                {
                    DateCheckInBill = DateTime.Now,
                    StatusBill = false,
                    Discount = 0,
                    TotalPrice = 0,
                    IdTable = idTable1
                };
                _context.Bills.Add(firstBill);
                _context.SaveChanges();
            }

            if (secondBill == null)
            {
                secondBill = new Bill
                {
                    DateCheckInBill = DateTime.Now,
                    StatusBill = false,
                    Discount = 0,
                    TotalPrice = 0,
                    IdTable = idTable2
                };
                _context.Bills.Add(secondBill);
                _context.SaveChanges();
            }

            var infos = _context.BillInfoes.Where(b => b.IdBill == firstBill.IdBill).ToList();
            foreach (var info in infos)
            {
                
                var existingInfo = secondBill.BillInfoes
                                      .FirstOrDefault(i => i.IdDrink == info.IdDrink);
                if (existingInfo != null)
                {
                   
                    existingInfo.Amount += info.Amount;
                    _context.BillInfoes.Remove(info);
                }
                else
                {
                   
                    info.IdBill = secondBill.IdBill;
                    secondBill.BillInfoes.Add(info);
                }
            }

            int secondCount = _context.BillInfoes.Count(b => b.IdBill == secondBill.IdBill);

            var t1 = _context.TableFoods.FirstOrDefault(t => t.IdTable == idTable1);
            if (t1 != null)
                t1.StatusTable = "Trống";
           
            var t2 = _context.TableFoods.FirstOrDefault(t => t.IdTable == idTable2);
            if (t2 != null)
                t2.StatusTable ="Có người";
           
            _context.SaveChanges();
        }

        public List<TableFood> GetTableFoods()
        {
            using (var context = new CoffeeManagementEntities1())
            {
                return context.TableFoods.ToList();
            }
        }
        public bool AddTable(string name)
        {
            var table = new TableFood
            {
                NameTable = name,
                StatusTable = "Trống"
            };
            _context.TableFoods.Add(table);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateTable(int id, string name)
        {
            var table = _context.TableFoods.FirstOrDefault(t => t.IdTable == id);
            if (table != null)
            {
                table.NameTable = name;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteTable(int id)
        {
            var table = _context.TableFoods.FirstOrDefault(t => t.IdTable == id);
            if (table != null)
            {
                _context.TableFoods.Remove(table);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

      
    }
}
