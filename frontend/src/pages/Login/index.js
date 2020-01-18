import React from 'react';
import { Button, Form, FormGroup, Label, Input } from 'reactstrap';
import api from '../../services/api';

export default class Login extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            titulo: 'Login Teste State'
        }

        this.handleClick = this.handleClick.bind(this);
    }

    componentDidMount() {
        // chamada ao backend usando axios (http)
    }

    async handleClick() {
        console.log('login')
        let response = await api.post('/user/autenticar', {
            username: 'teste'
        })
        console.log(response)
    }

    render() {
        let fontSize = this.props.fontSize;
        let titulo = this.state.titulo;

        return (
            <div style={{
                height: '100vh', 
                background: 'background: #FAFAFA;',
                display: 'flex',
                justifyContent: 'center',
                alignItems: 'center'
            }}>
                <div style={{
                    border: '1px solid #e6e6e6',
                    borderRadius: 1,
                    width: '350px',
                    padding: 30,
                    background: '#FFF'
                }}>
                    <h4>{titulo}</h4> 
                    <Form>
                        <FormGroup className="mb-2 mr-sm-2 mb-sm-0" >
                            <Label for="exampleEmail" className="mr-sm-2">Email</Label>
                            <Input type="email" name="email" id="exampleEmail" placeholder="something@idk.cool" style={{marginBottom: 10}}/>
                        </FormGroup>
                        <FormGroup className="mb-2 mr-sm-2 mb-sm-0">
                            <Label for="examplePassword" className="mr-sm-2">Password</Label>
                            <Input type="password" name="password" id="examplePassword" placeholder="don't tell!" style={{marginBottom: 10}}/>
                        </FormGroup>
                        <Button color="primary" style={{width: '100%'}}
                        onClick={this.handleClick}>Entrar</Button>
                    </Form>
                </div>
            </div>
        )
    }
}






















