import React, { useState } from 'react'
import axios from 'axios';
import { useHistory } from 'react-router-dom';

function RegisterPage(props) {

    const [data, setdata] = useState({ Username: '', Email: '', Password: '', PasswordAgain: '' })
    const apiUrl = "https://localhost:44314/api/Home/register";

    let history = useHistory();

    const Registration = (e) => {
        e.preventDefault();
        debugger;
        const data1 = { Username : data.Username, Email: data.Email, Password: data.Password, PasswordAgain: data.PasswordAgain };

        axios.post(apiUrl, data1)
            .then((result) => {
                debugger;
                console.log(result.data);
                if (result.data.Status == 'Invalid')
                    alert('Invalid User');
                else
                    history.push('/login')
            })
    }
    
    const onChange = (e) => {
        e.persist();
        debugger;
        setdata({ ...data, [e.target.name]: e.target.value });
    }

    return (
        <div class="container">
            <div class="card o-hidden border-0 shadow-lg my-5" style={{ "marginTop": "5rem!important;" }}>
                <div class="card-body p-0">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="p-5">
                                <div class="text-center">
                                    <h1 class="h4 text-gray-900 mb-4 textColor">Create a New User</h1>
                                </div>
                                <form onSubmit={Registration} class="user">
                                    <div class="form-group row">
                                        <div class="col-sm-6 mb-3 mb-sm-0">
                                            <input type="text" name="Username" onChange={onChange} value={data.Username} class="form-control" placeholder="Username" />
                                        </div>
                                        <div class="col-sm-6">
                                            <input type="email" name="Email" onChange={onChange} value={data.Email} class="form-control" id="exampleInputEmail" placeholder="Email" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <input type="password" name="Password" onChange={onChange} value={data.Password} class="form-control" id="exampleInputPassword" placeholder="Password" />
                                    </div>
                                    <div class="form-group">
                                        <input type="password" name="PasswordAgain" onChange={onChange} value={data.PasswordAgain} class="form-control" id="exampleInputPasswordAgain" placeholder="Password Again" />
                                    </div>
                                    <button type="submit" class="btn btn-primary btn-block">
                                        Register
                                    </button>
                                </form>                                
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default RegisterPage