import React from 'react'
import styles from '@/styles/Home.module.css'
import { useDispatch, useSelector } from 'react-redux'
import { reset } from '@/redux/userSlice';

const Index = () => {

    //redux işlemi
    const user = useSelector(state => state.user)
    const dispatch = useDispatch();

    return (
        <>
            <main className={styles.main}>

                    <button className="btn-primary !bg-success" onClick={() => dispatch(reset())} > Headeri Sil </button>
           
            </main>
        </>
    )
}

export default Index
