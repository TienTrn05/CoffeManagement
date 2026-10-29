using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace QuanLyQuanCaPhe.BLL
{
    public class DrinkBLL
    {
        private static DrinkBLL _instance;
        private readonly CoffeeManagementEntities1 _context;

        private DrinkBLL()
        {
            _context = new CoffeeManagementEntities1();
        }

        public static DrinkBLL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DrinkBLL();
                return _instance;
            }
        }

        public List<Drink> GetDrinksByIdCategory(int idCategory)
        {
            return _context.Drinks
                .Where(d => d.IdCategory == idCategory)
                .ToList();
        }

        public List<Drink> GetTable()
        {
            return _context.Drinks.ToList();
        }

        public List<Drink> SearchDrink(string keyword)
        {
            string processed = RemoveAccents(keyword).ToLower();
            List<Drink> result = new List<Drink>();

            foreach (var d in _context.Drinks.ToList())
            {
                string name = RemoveAccents(d.NameDrink).ToLower();
                if (name.Contains(processed))
                    result.Add(d);
            }

            return result;
        }

        public bool InsertDrink(string name, double price, int categoryId)
        {
            Drink newDrink = new Drink
            {
                NameDrink = name,
                PriceDrink = price,
                IdCategory = categoryId
            };

            _context.Drinks.Add(newDrink);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateDrink(int id, string name, double price, int categoryId)
        {
            var drink = _context.Drinks.FirstOrDefault(d => d.IdDrink == id);
            if (drink != null)
            {
                drink.NameDrink = name;
                drink.PriceDrink = price;
                drink.IdCategory = categoryId;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteDrink(int idDrink)
        {
            var drink = _context.Drinks.FirstOrDefault(d => d.IdDrink == idDrink);
            if (drink != null)
            {
                _context.Drinks.Remove(drink);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        private string RemoveAccents(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            var normalized = text.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();

            foreach (var c in normalized)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            }

            return sb.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
