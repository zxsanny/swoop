using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Forms;

namespace Swoop.Viewer
{
    public class GridWeight<T> where T: class
    {
        private readonly DataGridView grid;

        public static GridWeight<T> Fill(DataGridView grid)
        {
            return new GridWeight<T>(grid);
        }

        public GridWeight(DataGridView grid)
        {
            this.grid = grid;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public GridWeight<T> SetWidth(string name, int width)
        {
            try
            {
                grid.Columns[name].FillWeight = width;
            }
            catch (Exception)
            {
                // bad result is normal, its just UI
            }
            return this;
        }
        public GridWeight<T> SetWidth(Expression<Func<T, object>> selector, int width)
        {
            try
            {
                SetWidth(((selector.Body as UnaryExpression).Operand as MemberExpression).Member.Name, width);
            }
            catch (Exception)
            {
                // bad result is normal, its just UI
            }
            return this;
        }
    }
}
