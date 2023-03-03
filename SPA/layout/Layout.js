import Footer from '@/components/Footer'
import Header from '@/components/Header'
import SideBar from '@/components/SideBar'
import React from 'react'
import { useSelector } from 'react-redux'

const Layout = ({ children }) => {
    const userToken = useSelector(state => state.user.token);
    return (
        <React.Fragment>
            <div>
                {userToken && <Header />}
                <div className="container-fluid">
                    <div className="row">
            
                        {userToken && <SideBar />}
                        {children}
                  
                    </div>
                </div>
                {userToken && <Footer />}
            </div>
        </React.Fragment>
    )
}

export default Layout
