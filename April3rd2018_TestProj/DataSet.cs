using System.Collections.Generic;
using System.Linq;

namespace April3rd2018_TestProj
{
    public class DataSet
    {
        public const int TopLevelCategoryId = -1;

        public List<DataSetItem> Items { get; set; } = new List<DataSetItem>();

        public DataSet()
        {
            Items.Add(new DataSetItem() { CategoryId = 100, ParentCategoryId = TopLevelCategoryId, Name = "Business", Keywords = "Money" });
            Items.Add(new DataSetItem() { CategoryId = 200, ParentCategoryId = TopLevelCategoryId, Name = "Tutoring", Keywords = "Teaching" });
            Items.Add(new DataSetItem() { CategoryId = 101, ParentCategoryId = 100, Name = "Accounting", Keywords = "Taxes" });
            Items.Add(new DataSetItem() { CategoryId = 102, ParentCategoryId = 100, Name = "Taxation" });
            Items.Add(new DataSetItem() { CategoryId = 201, ParentCategoryId = 200, Name = "Computer" });
            Items.Add(new DataSetItem() { CategoryId = 103, ParentCategoryId = 101, Name = "Corporate Tax" });
            Items.Add(new DataSetItem() { CategoryId = 202, ParentCategoryId = 201, Name = "Operating System" });
            Items.Add(new DataSetItem() { CategoryId = 109, ParentCategoryId = 101, Name = "Small business Tax" });

            SetItemDepths();
        }

        private void SetItemDepths()
        {
            Items.ForEach(i => i.LevelsDeep = 1);

            foreach (var item in Items)
            {
                if (item.ParentCategoryId == TopLevelCategoryId)
                    continue;

                var currentParentLevel = item.ParentCategoryId;

                do
                {
                    var parent = Items.FirstOrDefault(x => x.CategoryId == currentParentLevel);

                    currentParentLevel = parent.ParentCategoryId;

                    item.LevelsDeep++;

                } while (currentParentLevel != TopLevelCategoryId);
            }
        }
    }

}
