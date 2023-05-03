using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Abstract
{
    public abstract class RequestParameters
    {
        const int _maxPageSize = 30;
        public int CurrentPage { get; set; } = 1;

        private int _pageSize;

        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                _pageSize = value > _maxPageSize ?
                    _maxPageSize :
                    value;
            }
        }

    }
}
