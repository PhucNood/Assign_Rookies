import React from "react";
import '../css/login.css'
import { Link } from "react-router-dom";
import { Formik, Form } from 'formik';
import * as Yup from "yup";
import { TextField } from "../component/TextField";
import axios from "axios";

export function LoginPage() {

    const schema = Yup.object({

        email: Yup.string().email('Invalid email').required('Require'),
        password: Yup.string().min(8, 'Must be at least 8 characters').required('Require'),

    })



    return (
        <Formik
            initialValues={
                {

                    email: ''
                    , password: ''

                }

            }
            validationSchema={schema}
            onSubmit={async values => {
                await axios.post('https://localhost:7040/Authorize/api/Token',{account:values.email,password:values.password}).then(
                    (response) => {
                        console.log(response.data);
                       localStorage.setItem('token', response.data)
                  
                       
                    }).catch((error) => {console.log(error);})

            }}
            
        

        >
            {formik => (



                <div id="login-row" className="row justify-content-center align-items-center">
                    <div id="login-column" className="col-md-6">
                        <div id="login-box" className="col-md-12">
                            <div>
                                <h1 className="my-4 font-weight-bold-display-4">Login</h1>

                                <Form onSubmit={formik.handleSubmit}>

                                    <TextField name="email" label="Email" type="email" />
                                    <TextField name="password" label="Password" type="password" />

                                    <button type="submit" className="btn btn-primary mt-3">Login</button>
                                    <div id="register-link" className="text-primary">
                                        <Link to="/register" className="text-primary">Register here</Link>
                                    </div>

                                </Form>
                            </div>
                        </div>
                    </div>
                </div>)


            }

        </Formik>

    )



}

