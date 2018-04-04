using System.Linq;

namespace April3rd2018_TestProj
{
    public class DataFetcher
    {
        private DataSet DataSet { get; set; } = new DataSet();
        private const string CategoryResultFormat = "ParentCategoryID={0}, Name={1}, Keywords={2}";

        public string FetchResult(int input)
        {         
            var result = DataSet.Items.FirstOrDefault(x => x.CategoryId == input);

            if (result != null && !string.IsNullOrWhiteSpace(result.Keywords))
            {
                return string.Format(CategoryResultFormat, result.ParentCategoryId, result.Name, result.Keywords);
            }

            if (result != null && string.IsNullOrWhiteSpace(result.Keywords))
            {
                return GetParentKeywordResult(result);
            }

            if (result == null && input <= DataSet.Items.Count)
            {
                return GetCategoryLevelResult(input);
            }

            return $"{input} not found";

        }

        private string GetParentKeywordResult(DateSetItem result)
        {
            string parentKeyword;
            var parentCategoryId = result.ParentCategoryId;

            do
            {
                var item = DataSet.Items.FirstOrDefault(x => x.CategoryId == parentCategoryId);

                if (!string.IsNullOrWhiteSpace(item.Keywords))
                {
                    parentKeyword = item.Keywords;
                    break;
                }
                else
                {
                    parentKeyword = null;
                    parentCategoryId = item.ParentCategoryId;
                }

            } while (string.IsNullOrEmpty(parentKeyword));

            return string.Format(CategoryResultFormat, result.ParentCategoryId, result.Name, parentKeyword);
        }

        private string GetCategoryLevelResult(int input)
        {
            var categoriesAtLevel = DataSet.Items
                                           .Where(x => x.LevelsDeep == input)
                                           .Select(x => x.CategoryId)
                                           .OrderBy(x => x)
                                           .ToList();

            if (categoriesAtLevel.Count == 0)
                return $"No items {input} deep";

            return string.Join(", ", categoriesAtLevel);
        }
    }
}
