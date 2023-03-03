import React from 'react'
import styles from '@/styles/Login.module.css';
import { useFormik } from "formik";
import { adminSchema } from "@/schema/admin";
import Link from 'next/link'
import { useState } from "react";

const Admin = () => {


const [email, setEmail] = useState('');

  const onSubmit = async (values, actions) => {
    await new Promise((resolve) => setTimeout(resolve, 1000));

    setEmail(values.email);
    
    actions.resetForm();
  };

  const { isValid, values, errors, touched, handleSubmit, handleChange, handleBlur } = useFormik({

    enableReinitialize: true,
    initialValues: {
      email: "",
      password: "",
    },
    onSubmit,
    validationSchema: adminSchema,
  });

  return (
    <>
      <form onSubmit={handleSubmit}>

        <div className={styles.sidenav}>
          <div className={styles.loginmaintext}>
            <h4>Admin<br /> Giriş Sayfası</h4>
            <p>Admin bu sayfadan giriş yapabilir</p>
          </div>
        </div>
        <div className={styles.main}>
          <br />
          <div className="col-md-6 col-sm-12">
            <div className={styles.loginform}>
              <h4 className='text-center'>Admin Girişi</h4>

              <div className="form-group">
                <label>Mail Adresiniz</label>
                <input type="email" id="email" name='email' className="form-control" value={values.email} onBlur={handleBlur} onChange={handleChange} placeholder="E-mailinizi giriniz" />
                {errors.email && touched.email ? <div className="text-danger small">{errors.email}</div> : null}
              </div>
              <br />
              <div className="form-group">
                <label>Şifreniz</label>
                <input type="password" id="password" name='password' className="form-control" value={values.password} onBlur={handleBlur} onChange={handleChange} placeholder="Şifrenizi giriniz" />
                {errors.password && touched.password ? <div className="text-danger small">{errors.password}</div> : null}
              </div>
              <br />
              <div className='text-center'>
                <button type="submit" className="btn btn-secondary btn-xs" style={{ width: "80%" }} disabled={!isValid}>Giriş Yap</button>
              </div>
              <br/>
               <div className='pulleft small'>
                <Link href="/" legacyBehavior><u>Ana Sayfa</u></Link>
               </div>

              <br />
            </div>
          </div>
        </div>
      </form>
    </>
  )
}

export default Admin
