import React from 'react'
import styles from '@/styles/Login.module.css';
import { useFormik } from "formik";
import { loginSchema } from "@/schema/login";
import { useRouter } from "next/router";
import { useDispatch, useSelector } from 'react-redux'
import { addUser } from '@/redux/userSlice';
import { axiosFrontendServer } from '@/services/axios';


const Login = () => {

//redux işlemi
  const user = useSelector(state => state.user)
  const dispatch = useDispatch();
 
  const router = useRouter(); 

  const onSubmit = async (values, actions) => {
    const { email, password } = values;    
    try {
      const res = await axiosFrontendServer.post("/auth/login", { email, password });
      dispatch(addUser({token:true, email }));
      router.push("/");
      actions.resetForm();
    } catch (err) {
      console.log(err);
    }
  };

  const { isValid, values, errors, touched, handleSubmit, handleChange, handleBlur } = useFormik({

    enableReinitialize: true,
    initialValues: {
      email: "",
      password: "",
    },
    onSubmit,
    validationSchema: loginSchema,
  });

  return (
    <>
      <form onSubmit={handleSubmit}>

        <div className={styles.sidenav}>
          <div className={styles.loginmaintext}>
            <h2>Kullanıcı<br /> Giriş Sayfası</h2>
            <p>Kullanıcılar bu sayfadan giriş yapabilir</p>
          </div>
        </div>
        <div className={styles.main}>
          <br />
          <div className="col-md-6 col-sm-12">
            <div className={styles.loginform}>
              <h4 className='text-center'>Kullanıcı Girişi</h4>

              <div className="form-group">
                <label>Mail Adresiniz= cuneytaran@gmail.com</label>
                <input type="email" id="email" name='email' className="form-control" value={values.email} onBlur={handleBlur} onChange={handleChange} placeholder="E-mailinizi giriniz" />
                {errors.email && touched.email ? <div className="text-danger small">{errors.email}</div> : null}
              </div>
              <br />
              <div className="form-group">
                <label>Şifreniz= Admin@1234</label>
                <input type="password" id="password" name='password' className="form-control" value={values.password} onBlur={handleBlur} onChange={handleChange} placeholder="Şifrenizi giriniz" />
                {errors.password && touched.password ? <div className="text-danger small">{errors.password}</div> : null}
              </div>
              <br />
              <div className='text-center'>
                <button type="submit" className="btn btn-secondary btn-xs" style={{ width: "80%" }} disabled={!isValid} >Giriş Yap</button>
              </div>

              <br />
            </div>
          </div>
        </div>
      </form>
    </>
  )
}

export default Login
