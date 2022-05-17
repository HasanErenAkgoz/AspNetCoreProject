using Entity.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
  public  class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Kategori Adı Boş Geçilemez");
            RuleFor(x => x.Description).NotNull().WithMessage("Kategori Açıklamasını Boş Geçilemez");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Kategori Adı En Az 3 Karakter Olmalıdır.");
        }
    }
}
