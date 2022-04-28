using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotHandlerSourceParent.Entity
{
    class Source
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public string SelectorSubUrl { get; set; }
        public string SelectorTitle { get; set; }
        public string SelectorImage { get; set; }
        public string SelectorDescrition { get; set; }
        public string SelectorContent { get; set; }
        public string CategoryId { get; set; }

        public override string ToString()
        {
            return "Id: " + Id + " | " +
                 "Url: " + Url + " | " +
                 "SubUrl: " + SelectorSubUrl + " | " +
                 "Title: " + SelectorTitle + " | " +
                 "Image: " + SelectorImage + " | " +
                 "Descrition: " + SelectorDescrition + " | " +
                 "Content: " + SelectorContent + " | " +
                 "CategoryId: " + CategoryId;
        }
    }
}
