import React from "react";
import '../css/login.css'
import { useFormik } from 'formik';
import * as Yup from "yup";


export function LoginPage() {
    const formik = useFormik({
        initialValues: {
            email: "",
            password: "",
        },
        validationSchema: Yup.object({

            email: Yup.string()
                .email("Invalid email format")
                .required("Required!"),
            password: Yup.string()
                .min(8, "Minimum 8 characters")
                .required("Required!"),

        }),

    });

    return (<div className="container">

        <div id="login-row" className="row justify-content-center align-items-center">
            <div id="login-column" className="col-md-6">
                <div id="login-box" className="col-md-12">
                    <form id="login-form" className="form" action="" method="post" >
                        <h3 className="text-center text-dark">Login</h3>
                        <div className="form-group">
                            <label htmlFor="email" className="text-dark">Email:</label><br />
                            <input type="email" name="email" id="email" className="form-control"
                                value={formik.values.email} onChange={formik.handleChange}
                            />
                        </div>
                        <p style={{ color: 'red' }}>{formik.errors.email}</p>
                        <div className="form-group">
                            <label htmlFor="password" className="text-dark">Password:</label><br />
                            <input type="password" name="password" id="password" className="form-control"
                                value={formik.values.password} onChange={formik.handleChange}
                            />
                        </div>
                        <p style={{ color: 'red' }}>{formik.errors.password}</p>
                        <div className="form-group">
                            <label htmlFor="remember-me" className="text-dark"><span>Remember me</span> <span>

                                <input id="remember-me" name="remember-me" type="checkbox" /></span></label><br />

                            <input type="submit" name="submit" className="btn btn-dark btn-md" value="submit" />
                        </div>
                        <div id="register-link" className="text-dark">
                            <a href="#" className="text-dark">Register here</a>
                        </div>
                    </form>
                </div>
            </div>
        </div>

    </div>
    );




}

