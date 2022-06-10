import { useForm } from "react-hook-form";
import {Form, Button, Row, Col, Card} from 'react-bootstrap';
import Logo from '../../components/logo/Logo';
import { useTranslation } from 'react-i18next';
import { useContext } from "react";
import { Context } from "../../context/AuthProvider";

export default function Login() {
    const{handleLogin} = useContext(Context);
    const{t} = useTranslation();
    const{handleSubmit, register, formState: { errors }} = useForm();
    const onSubmit = async data => {
        console.log(data);
        handleLogin(data);
    }
    return (
        <>
            <Row>
                <Col>
                    <div className='d-flex align-items-center justify-content-center logo-box-lg'>
                        <h1 className='logo'><Logo/></h1>      
                    </div>
                </Col>
                <Col>   
                    <Card>
                        <Card.Body>
                            <Card.Title>{t("title.login")}</Card.Title>
                            <Form onSubmit={handleSubmit(onSubmit)}>
                            <Form.Group className="mb-3" controlId="formBasicEmail">
                                    <Form.Label>{t("label.emailAddress")}</Form.Label>
                                    <Form.Control 
                                        type="email" 
                                        placeholder={t("placeholder.enterEmail")} 
                                        className={errors.username ? 'is-invalid' : ''}
                                        {...register("username", { required: true })}  
                                    />
                                    {errors.username && <Form.Text className="invalid-feedback">{t("error.required")}<br/></Form.Text>}
                                </Form.Group>

                                <Form.Group className="mb-3" controlId="formBasicPassword">
                                    <Form.Label>{t("label.password")}</Form.Label>
                                    <Form.Control 
                                        type="password" 
                                        placeholder={t("placeholder.password")} 
                                        className={errors.password ? 'is-invalid' : ''}
                                        {...register("password", { required: true, min: 8, max: 20 })} 
                                    />
                                    {errors.password && <Form.Text className="invalid-feedback">{t("error.required")}</Form.Text>}
                                </Form.Group>
                                <Button variant="primary" type="submit">
                                    {t("btn.login")}
                                </Button>
                            </Form>
                        </Card.Body>
                    </Card>                                 
                </Col>
            </Row>
        </>
    )
}
