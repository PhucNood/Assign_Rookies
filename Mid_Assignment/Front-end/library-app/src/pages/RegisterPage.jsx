import React from "react";
import '../css/login.css'
import { Formik, Form } from 'formik';
import * as Yup from "yup";
import { TextField } from "../component/TextField";
import axios from "axios";
import { useNavigate } from "react-router-dom";



export function RegisterPage() {
    const phoneRegExp = /^((\\+[1-9]{1,4}[ \\-]*)|(\\([0-9]{2,3}\\)[ \\-]*)|([0-9]{2,4})[ \\-]*)*?[0-9]{3,4}?[ \\-]*[0-9]{3,4}?$/
    const schema = Yup.object({
        firstName: Yup.string().min(2, 'Must be at least 2 characters').required('Require'),
        lastName: Yup.string().min(2, 'Must be at least 2 characters').required('Require'),
        email: Yup.string().email('Invalid email').required('Require'),
        password: Yup.string().min(8, 'Must be at least 15 characters').required('Require'),
        confirm_password: Yup.string().oneOf([Yup.ref("password"), null], "Password must match").required('Require'),
        phoneNumber: Yup.string().matches(phoneRegExp, 'Phone number is not valid')
    })


    const navigatge = useNavigate();
    return (
        <Formik
            initialValues={
                {
                    firstName: ''
                    , lastName: ''
                    , email: ''
                    ,gender : 0
                    ,address: ''
                    ,phone: '',
                    dateOfBirth: ''
                   , email: ''
                    , password: ''
                    , confirm_password: ''
                }

            }
            validationSchema={schema}
        onSubmit={async values => {
            var x = document.getElementById("myDate").value;
          await  axios.post('https://localhost:7040/User/api/User', {
                userName: values.firstName + " " + values.lastName,
                gender: values.gender,
                address: values.address,
                phone: values.phone,              
                dateOfBirth:new Date(x),
                account: values.email,
                password: values.password,
                isSuper:false
                
               

            }).then(response => {
                console.log(response)
                navigatge ('/login');
                    window.location.reload();
            }).catch(err => {
                console.log(err)
            })
        }}

       

        >
            {formik => (



                <div id="login-row" className="row justify-content-center align-items-center">
                    <div id="login-column" className="col-md-6">
                        <div id="login-box" className="col-md-12">
                            <div>
                                <h1 className="my-4 font-weight-bold-display-4">Register</h1>

                                <Form onSubmit={formik.handleSubmit}>

                                    <TextField name="firstName" label="First Name" type="text" />
                                    <TextField name="lastName" label="Lastname" type="text" />
                                    <div className="mp-3">
                                    <label htmlFor="gender">Gender:</label>
                                    <select className="form-control" name="gender" id="cars">
                                        <option value="0">Male</option>
                                        <option value="1">Female</option>
                                        <option value="2">Other</option>
                                    
                                    </select>
                                    </div>
                                    <TextField name="address" label="Address" type="text" />
                                    <TextField name="phone" label="Phone number" type="text" />
                                    <TextField id="myDate" name=" dateOfBirth" label="Date of birth" type="date" placeholder="dd-mm-yyyy" />
                                    <TextField name="email" label="Email" type="email" />
                                    <TextField name="password" label="Password" type="password" />
                                    <TextField name="confirm_password" label="Confirm Password" type="password" />
                                    <button type="submit" className="btn btn-primary mt-3">Register</button>
                                   
                                </Form>
                            </div>
                        </div>
                    </div>
                </div>)


            }

        </Formik>

    )

}