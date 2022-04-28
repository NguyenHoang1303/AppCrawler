﻿using BotHandlerSourceParent.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotHandlerSourceParent.Queue
{
    class EventQueue
    {
        public string Url { get; set; }
        public string SelectorTitle { get; set; }
        public string SelectorImage { get; set; }
        public string SelectorDescrition { get; set; }
        public string SelectorContent { get; set; }
        public string CategryId { get; set; }

        public EventQueue(string url, Source source)
        {
            this.Url = url;
            this.SelectorTitle = source.SelectorTitle;
            this.SelectorImage = source.SelectorImage;
            this.SelectorDescrition = source.SelectorDescrition;
            this.SelectorContent = source.SelectorContent;
            this.CategryId = source.CategoryId;
        }

        public EventQueue()
        {
        }

        public override string ToString()
        {
            return "Url: " + Url + "\n" 
                + "Title: " + SelectorTitle + "\n" 
                + "Image: " + SelectorImage + "\n" 
                + "Description: " + SelectorDescrition + "\n" 
                + "Content: " + SelectorContent + "\n"
                + "CategoryId: " + CategryId;
        }
    }
}
