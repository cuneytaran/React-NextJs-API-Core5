import React from 'react'
import Link from 'next/link'

import { useSelector } from 'react-redux'
import { setCookie } from 'cookies-next';

const Header = () => {


    const userData = useSelector(state => state.user);
    const handleExit = () => {
        setCookie("access_token", "", { expires: new Date(0) });
    }


    return (
        <>

            {/* header */}
            <nav className="navbar navbar-dark sticky-top bg-dark flex-md-nowrap p-0">
                <Link href={"/home"} legacyBehavior><a className="navbar-brand col-sm-3 col-md-2 mr-0">Home</a></Link>
                <ul className="navbar-nav px-3">
                    <li className="nav-item text-nowrap">              
                        <span className='nav-link p-0 m-0'>{userData.email}</span>
                    </li>
                    <li className="nav-item text-nowrap">
                        <Link href="/auth/login" legacyBehavior ><a onClick={() => handleExit()} style={{ color: "white" }}><i className="fa fa-power-off" aria-hidden="true"  ></i> Sing Out</a></Link>
                    </li>
                </ul>
            </nav>

        </>
    )
}

export default Header
