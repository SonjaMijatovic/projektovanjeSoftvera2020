using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Model
{
    public class PageModel
    {
        private int page = 0;
        private int perPage = 30;
        private string search = string.Empty;
        private User user;

        public PageModel()
        {

        }
        public PageModel(int page, int perPage, string search)
        {
            this.page = page;
            this.perPage = perPage > 0 ? perPage : 30;
            this.search = search == null ? string.Empty : search;
        }

        public PageModel(int page, int perPage, string search, User user)
        {
            this.page = page;
            this.perPage = perPage > 0 ? perPage : 30;
            this.search = search == null ? string.Empty : search;
            this.user = user;
        }

        public User User { 
            get { return user; }
            set { user = value; }
        }

        public int Page
        {
            get { return page; }
            set { page = value; }
        }
        public int PerPage
        {
            get { return perPage; }
            set { perPage = value; }
        }
        public string Search
        {
            get { return search; }
            set { search = value; }
        }
    }
}
