using ROC.Modles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROC.BLL
{
    public partial interface IMenuClassService
    {
        List<JsonTree> GetMenuTree();
    }
    /// <summary>
    /// 菜单服务类
    /// </summary>
    public partial class MenuClassService
    {
        public List<JsonTree> GetMenuTree()
        {
            var list = this.Get(t => true).ToList<MenuClass>();
            return CreateTree(list, null);
        }
        private List<JsonTree> CreateTree(List<MenuClass> list,string pid)
        {
            List<MenuClass> rootList = list.FindAll(t => t.ParentCode==pid);
            List<JsonTree> rootNode = new List<JsonTree>();
            foreach(var item in rootList)
            {
                JsonTree node = new JsonTree();
                node.id = item.Code;
                node.text = item.Name;
                node.attributes = new attributes();
                node.children = CreateTree(list, item.Code);
                rootNode.Add(node);
            }
            return rootNode;
        }
    }

    public class JsonTree
    {
        public string id { get; set; }
        public string text { get; set; }
        public attributes attributes { get; set; }
        public List<JsonTree> children { get; set; }
    }

    public class attributes
    {
        public string url { get; set; }
    }
}
