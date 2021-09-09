import React, { useState, useEffect } from 'react'
import axios from 'axios';
import { useHistory } from 'react-router-dom';

function LoginPage(props) {
    const [user, setUser] = useState({ Username: '', Password: '' });
    const apiUrl = "https://localhost:44314/api/Home/login";

    let history = useHistory();

    const Login = (e) => {
        e.preventDefault();
        debugger;
        const data = { Username: user.Username, Password: user.Password };

        localStorage.setItem("loginUser", data.Username);

        axios.post(apiUrl, data)
            .then((result) => {
                debugger;
                //console.log(result.data);
                const serializedState = JSON.stringify(result.data.loginUser);
                var a = localStorage.setItem('myData', serializedState);
                
                const user = result.data.loginUser;
                
                if (result.data.status == '200')
                    props.history.push('/todoList')
                else
                    alert('Invalid User');
            })

    };

    const onChange = (e) => {
        e.persist();
        debugger;
        setUser({ ...user, [e.target.name]: e.target.value });
    }
    return (

        <div class="container">
            <div class="row justify-content-center">
                <div class="col-xl-10 col-lg-12 col-md-9">
                    <div class="card o-hidden border-0 shadow-lg my-5">
                        <div class="card-body p-0">
                            <div class="row">
                                
                                <div class="col-lg-6">
                                    <div class="p-5">
                                        <div class="text-center">
                                            <h1 class="h4 text-gray-900 mb-4 textColor">Welcome Back!</h1>
                                        </div>
                                        <form class="user">
                                            <div class="form-group">
                                                <input type="text" class="form-control" value={user.Username} onChange={onChange} name="Username" id="Username" placeholder="Username" />
                                            </div>
                                            <div class="form-group">
                                                <input type="password" class="form-control" value={user.Password} onChange={onChange} name="Password" id="DepPasswordartment" placeholder="Password" />
                                            </div>
                                            <button onClick={() => { history.push('/todoList') }} type="submit" className="btn btn-info mb-1" block><span>Login</span></button>                                            
                                        </form>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default LoginPage