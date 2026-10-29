using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace QuanLyQuanCaPhe.BLL
{
    public class CategoryBLL
    {
        private static CategoryBLL _instance;
        private readonly CoffeeManagementEntities1 _context;

        private CategoryBLL()
        {
            _context = new CoffeeManagementEntities1();
        }

        public static CategoryBLL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CategoryBLL();
                return _instance;
            }
        }

        public List<Category> GetTable()
        {
            return _context.Categories.ToList();
        }

        public List<Category> SearchCategories(string keyword)
        {
            string processed = RemoveAccents(keyword).ToLower();
            List<Category> result = new List<Category>();

            foreach (var c in _context.Categories.ToList())
            {
                string name = RemoveAccents(c.NameCategory).ToLower();
                if (name.Contains(processed))
                    result.Add(c);
            }

            return result;
        }

        public bool InsertCategory(string nameCategory)
        {
            Category newCate = new Category { NameCategory = nameCategory };
            _context.Categories.Add(newCate);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateCategory(int idCategory, string nameCategory)
        {
            var cate = _context.Categories.FirstOrDefault(c => c.IdCategory == idCategory);
            if (cate != null)
            {
                cate.NameCategory = nameCategory;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteCategory(int idCategory)
        {
            var relatedDrinks = _context.Drinks.Where(d => d.IdCategory == idCategory).ToList();
            foreach (var d in relatedDrinks)
            {
                _context.Drinks.Remove(d);
            }

            var cate = _context.Categories.FirstOrDefault(c => c.IdCategory == idCategory);
            if (cate != null)
            {
                _context.Categories.Remove(cate);
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
