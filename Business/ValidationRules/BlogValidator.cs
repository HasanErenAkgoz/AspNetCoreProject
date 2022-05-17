using Entity.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
   public class BlogValidator:AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Blog Başlığını Boş Geçemezsiniz");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Blog İçeriğini Boş Geçemezsiniz");
            RuleFor(x => x.ThumbnailImage).NotEmpty().WithMessage("Blog Görselini Boş Geçemezsiniz");
            RuleFor(x => x.Title).MaximumLength(150).WithMessage("Lütfen 150 karakterden daha az veri girişi yapın");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Lütfen 5 karakterden daha fazla veri girişi yapın");
        }
    }
}
