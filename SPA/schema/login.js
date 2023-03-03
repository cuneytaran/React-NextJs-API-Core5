import * as Yup from "yup";

export const loginSchema = Yup.object({
  email: Yup.string().required("E-mail girmek zorunludur.").email("E-mail hatalı."),
  password: Yup.string()
  .required("Şifre girmek zorunludur.")
    .min(8, "Şifre en az 8 karakter olmalıdır.")
    .matches(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/,
      "Parola en az bir büyük harf, bir küçük harf, bir sayı ve bir özel karakter içermelidir."
    ),
});
