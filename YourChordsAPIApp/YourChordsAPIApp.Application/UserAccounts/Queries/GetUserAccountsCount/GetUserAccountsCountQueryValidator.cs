using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourChordsAPIApp.Application.UserAccounts.Queries.GetUserAccountsCount
{
    public class GetUserAccountsCountQueryValidator : AbstractValidator<GetUserAccountsCountQuery>
    {
        public GetUserAccountsCountQueryValidator()
        {
            // Thêm các quy tắc kiểm tra cần thiết tùy theo yêu cầu
        }
    }

}
