using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AboutValidator : AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x=>x.Description).NotEmpty().WithMessage("Açıklama Kısmı Boş Olamaz !");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık Kısmı Boş Olamaz !");
            RuleFor(x => x.SecondTitle).NotEmpty().WithMessage("Başlık Kısmı Boş Olamaz !");
            RuleFor(x => x.FirstImageUrl).NotEmpty().WithMessage("Görsel Kısmı Boş Olamaz !");
            RuleFor(x => x.SecondDescription).NotEmpty().WithMessage("Görsel Kısmı Boş Olamaz !");

            RuleFor(x => x.Description).MinimumLength(20).WithMessage("Bu Alan En Az 20 Karakter İçermelidir!");
            RuleFor(x => x.SecondDescription).MinimumLength(20).WithMessage("Bu Alan En Az 20 Karakter İçermelidir!");

            RuleFor(x => x.Description).MaximumLength(400).WithMessage("Bu Alan En Fazla 400 Karakter İçermelidir!");
            RuleFor(x => x.SecondDescription).MaximumLength(400).WithMessage("Bu Alan En Fazla 400 Karakter İçermelidir!");

            RuleFor(x=>x.Title).MaximumLength(50).WithMessage("Bu Alan En Fazla 50 Karakter İçermelidir!");
            RuleFor(x=>x.SecondTitle).MaximumLength(50).WithMessage("Bu Alan En Fazla 50 Karakter İçermelidir!");

        }
    }
}
