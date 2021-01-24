import React from 'react'
import {bindActionCreators} from "redux";
import * as Actions from "../../../actions/Actions";
import {withRouter} from "react-router-dom";
import connect from "react-redux/es/connect/connect";
import Grid from '@material-ui/core/Grid';
import {Paper} from "@material-ui/core";
import strings from "../../../localization";
import Validators from "../../../constants/ValidatorTypes";
import FormComponent from "../../../common/FormComponent";
import UserForm from "../../../components/forms/admin/user/UserForm";
import {addUser} from "../../../services/admin/UserAdminService";
import {withSnackbar} from "notistack";

class AddUser extends FormComponent {

    validationList = {
        email: [ {type: Validators.EMAIL } ],
        firstName: [ {type: Validators.REQUIRED } ],
        lastName: [ {type: Validators.REQUIRED } ]
    };

    constructor(props) {
        super(props);

        this.state = {
            data: props.data ? props.data : {},
            errors: {}
        };

        this.props.changeFullScreen(false);

        this.submit = this.submit.bind(this);
    }

    submit() {

        if(!this.validate()) {
            return;
        }

        this.showDrawerLoader();

        let data = {
            email: this.state.data.email,
            firstName: this.state.data.firstName,
            lastName: this.state.data.lastName,
            password: this.state.data.password,
            userType: this.state.data.userType ? this.state.data.userType.value : '',
            doctorType:  this.state.data.doctorType ? { id: this.state.data.doctorType.id} : null
        }

        addUser(data).then(response => {

            if(!response.ok) {
                this.props.onFinish(null);
                this.props.enqueueSnackbar(strings.addUser.errorAddingUser, { variant: 'error' });
                return;
            }

            this.props.enqueueSnackbar(strings.addUser.userAdded, { variant: 'success' });
            this.props.onFinish(response.data.user);

            this.hideDrawerLoader();
        });
    }

    render() {

        return (
            <Grid id='page' item md={ 12 }>

                <div className='header'>
                    <h1>{ strings.addUser.pageTitle }</h1>
                </div>

                <Paper className='paper'>
                    <UserForm doctoreTypes={ this.props.doctoreTypes } onChange={ this.changeData } onSubmit={ this.submit }
                                data={ this.state.data } errors={ this.state.errors } onCancel={ this.props.onCancel }/>
                </Paper>

            </Grid>

        );
    }
}


function mapDispatchToProps(dispatch)
{
    return bindActionCreators({
        changeFullScreen: Actions.changeFullScreen
    }, dispatch);
}

function mapStateToProps({ menuReducers, siteDataReducers })
{
    return { menu: menuReducers, siteData: siteDataReducers };
}

export default withSnackbar(withRouter(connect(mapStateToProps, mapDispatchToProps)(AddUser)));