using Entity.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
  public  class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen  Boş Geçmeyiniz");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapınız");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Lütfen  Boş Geçmeyiniz");
            RuleFor(x => x.Mail).EmailAddress().WithMessage("Lütfen geçerli bir e-mail giriniz.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Lütfen  Boş Geçmeyiniz");
            RuleFor(x => x.Password).MinimumLength(6).WithMessage("Parolanız en az 6 karakter içermelidir.");
            RuleFor(x => x.Password).Must(IsPasswordValid).WithMessage("Parolanızda en az bir küçük harf bir büyük harf ve rakam içermelidir.");
        }
        private bool IsPasswordValid(string arg)
        {
            try
            {
                Regex regex = new Regex(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[0-9])[A-Za-z\d]");
                return regex.IsMatch(arg);
            }
            catch
            {
                return false;
            }
        }
    }
}
