using System.Collections.Generic;
using System.Linq;

namespace April3rd2018_TestProj
{
    public class DataSet
    {
        public const int ParentLevelCategoryId = -1;

        public List<DateSetItem> Items { get; set; } = new List<DateSetItem>();

        public DataSet()
        {
            Items.Add(new DateSetItem() { CategoryId = 100, ParentCategoryId = ParentLevelCategoryId, Name = "Business", Keywords = "Money" });
            Items.Add(new DateSetItem() { CategoryId = 200, ParentCategoryId = ParentLevelCategoryId, Name = "Tutoring", Keywords = "Teaching" });
            Items.Add(new DateSetItem() { CategoryId = 101, ParentCategoryId = 100, Name = "Accounting", Keywords = "Taxes" });
            Items.Add(new DateSetItem() { CategoryId = 102, ParentCategoryId = 100, Name = "Taxation" });
            Items.Add(new DateSetItem() { CategoryId = 201, ParentCategoryId = 200, Name = "Computer" });
            Items.Add(new DateSetItem() { CategoryId = 103, ParentCategoryId = 101, Name = "Corporate Tax" });
            Items.Add(new DateSetItem() { CategoryId = 202, ParentCategoryId = 201, Name = "Operating System" });
            Items.Add(new DateSetItem() { CategoryId = 109, ParentCategoryId = 101, Name = "Small business Tax" });

            SetItemDepths();
        }

        private void SetItemDepths()
        {
            Items.ForEach(i => i.LevelsDeep = 1);

            foreach (var item in Items)
            {
                if (item.ParentCategoryId == ParentLevelCategoryId)
                    continue;

                var currentParentLevel = item.ParentCategoryId;

                do
                {
                    var parent = Items.FirstOrDefault(x => x.CategoryId == currentParentLevel);

                    currentParentLevel = parent.ParentCategoryId;

                    item.LevelsDeep++;

                } while (currentParentLevel != ParentLevelCategoryId);
            }
        }
    }

}
