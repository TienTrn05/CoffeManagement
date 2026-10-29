using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyQuanCaPhe.BLL
{
    public class BillInfoBLL
    {
        private static BillInfoBLL _instance;
        private readonly CoffeeManagementEntities1 _context;

        private BillInfoBLL()
        {
            _context = new CoffeeManagementEntities1();
        }

        public static BillInfoBLL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new BillInfoBLL();
                return _instance;
            }
        }

        public void InsertBillInfo(int idBill, int idDrink, int amount)
        {
            var existing = _context.BillInfoes.FirstOrDefault(b => b.IdBill == idBill && b.IdDrink == idDrink);
            if (existing != null)
            {
                int newAmount = existing.Amount + amount;
                if (newAmount > 0)
                {
                    existing.Amount = newAmount;
                }
                else
                {
                    _context.BillInfoes.Remove(existing);
                }
            }
            else
            {
                if (amount > 0)
                {
                    BillInfo newInfo = new BillInfo
                    {
                        IdBill = idBill,
                        IdDrink = idDrink,
                        Amount = amount
                    };
                    _context.BillInfoes.Add(newInfo);
                }
            }
            _context.SaveChanges();
        }

        public List<object> GetBillInfoByIdBill(int idBill)
        {
            var list = (from bi in _context.BillInfoes
                        where bi.IdBill == idBill
                        select new
                        {
                            TenMon = bi.Drink != null ? bi.Drink.NameDrink : "",
                            Gia = bi.Drink != null ? bi.Drink.PriceDrink : 0,
                            SoLuong = bi.Amount,
                            ThanhTien = (bi.Drink != null ? bi.Drink.PriceDrink : 0) * bi.Amount
                        }).ToList<object>();

            return list;
        }
    }
}
