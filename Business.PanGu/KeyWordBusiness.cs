using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PanGu;
using PanGu.Dict;
using SearchEngine.Helper;
using SearchEngine.Model;
namespace Business.PanGu
{
    public class KeyWordBusiness
    {

        private static WordDictionary _word;
        private static WordDictionary Word
        {
            get
            {
                if (null == _word)
                {
                    _word = new WordDictionary();
                    string config = Config.GetPanGuWordFilePath();
                    _word.Load(config);
                }
                return _word;
            }
        }

        /// <summary>
        /// 添加关键词
        /// </summary>
        public static void Insert(List<string> keywords)
        {
            foreach (var item in keywords)
            {
                Word.InsertWord(item, 0, POS.POS_D_A);
            }
            //保存至文件
            Word.Save(Config.GetPanGuWordFilePath());

        }
        /// <summary>
        /// 添加关键词默认都是形容词
        /// </summary>
        /// <param name="keyword"></param>
        public static bool Insert(string keyword)
        {

            if (Word.InsertWord(keyword, 0, POS.POS_D_A) != KeyWordEnum.Failure)
            {
                //保存至文件
                Word.Save(Config.GetPanGuWordFilePath());
                return true;
            }
            return false;
        }

        public static void Delete(string keyword)
        {
            Word.DeleteWord(keyword.Trim());
            Word.Save(Config.GetPanGuWordFilePath());
        }

        /// <summary>
        /// 删除关键词
        /// </summary>
        public static void Delete(List<string> keywords)
        {
            foreach (var item in keywords)
            {
                Word.DeleteWord(item.Trim());
            }
            Word.Save(Config.GetPanGuWordFilePath());
        }
        /// <summary>
        /// 是否存在关键词
        /// </summary>
        public static bool IsHas(string keyword)
        {
            var temp = Word.Search(keyword);
            if (temp == null || !temp.Any()) return false;
            return true;
        }
        /// <summary>
        /// 查询搜索
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="count"></param>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public List<string> Search(string keyword, out int count, int pageindex = 1, int pagesize = 10)
        {

            count = 0;
            if (keyword.Trim() == string.Empty)
                return null;
            var list = Word.Search(keyword);
            if (list == null && !list.Any()) return null;
            var sp = list.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
            return (from m in sp
                    select m.Word.ToString()).ToList();
        }
        /// <summary>
        /// 分页加载
        /// </summary>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<string> Load(out int count, int pageindex = 1, int pagesize = 10)
        {
            count = 0;
            if (Word.TempAll != null)
            {
                count = Word.TempAll.Count();
                return Word.TempAll.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
            }
            return null;
        }
    }
}
