import axios from 'axios';
import { useState } from 'react'
import React, { useEffect } from "react";


const Users = () => {
    const [users, setUsers] = useState()

    useEffect(() => {
        let isMounted = true;
        const controller = new AbortController();

        const getUsers = async () => {
            try {
                const response = await axios.get('/users', { signal: controller.signal })
              
                if (isMounted) {
                    setUsers(response.data)
                }
            } catch (err) {
                console.log(err)
            }
        }
        getUsers();
        return () => {
            isMounted = false;
            controller.abort();
        }
    }, [])

    return (
        <article>

            <h2>Users List</h2>
            {users?.length
                ? (
                    <ul>
                        {users.map((user, i) => <li key={i}>{user?.name}</li>)}
                    </ul>
                ) : <p>No Users to display</p>
            }

        </article>
    )
}

export default Users
