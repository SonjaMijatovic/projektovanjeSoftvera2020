import React, {Component} from 'react'
import {bindActionCreators} from "redux";
import {Link, withRouter} from "react-router-dom";
import {connect} from "react-redux";
import MenuState from "../constants/MenuState";

import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';
import SendIcon from '@material-ui/icons/Send';
import ExpandLess from '@material-ui/icons/ExpandLess';
import ExpandMore from '@material-ui/icons/ExpandMore';
import Collapse from '@material-ui/core/Collapse';
import {Drawer} from "@material-ui/core";

class Navigation extends Component {

    constructor(props) {
        super(props);

        this.state = {

            submenu: {
                example: false
            }
        };
    }

    componentWillReceiveProps(props) {
        console.log(this.props.auth);
    }

    getNavigationClass() {

        if(this.props.menu.state === MenuState.SHORT) {
            return 'navigation-content-container short';
        }
        else {
            return 'navigation-content-container'
        }
    }

    isCurrentPath(path) {

        return this.props.history.location.pathname == path;
    }

    toggleSubmenu(key) {

        let submenu = this.state.submenu;

        submenu[key] = !submenu[key];

        this.setState({
            submenu: submenu
        });
    }

    isAdmin() {
        return this.props.auth.user && this.props.auth.user.userType == 'ADMIN';
    }

    render() {
        
        return (
            <Drawer variant="permanent" id='navigation'>

                <div className={ this.getNavigationClass() }>
                    <div className='logo-container'>

                        <div className='logo'>
                            <SendIcon/>
                        </div>
                        <div className='title'>
                            <h2>PSV</h2>
                        </div>
                    </div>
                    <List component="nav">
                        <Link to={'/'} className={ this.isCurrentPath('/') ? 'navigation-link active' : 'navigation-link'} >
                            <ListItem className='navigation-item'>

                                <ListItemIcon className='navigation-icon'>
                                    <SendIcon/>
                                </ListItemIcon>

                                <ListItemText inset primary='Home' className='navigation-text'/>

                            </ListItem>
                        </Link>
                        {
                            this.isAdmin() &&
                            <React.Fragment>
                                <Link to={'/users'} className={ this.isCurrentPath('/users') ? 'navigation-link active' : 'navigation-link'} >
                                    <ListItem className='navigation-item'>

                                        <ListItemIcon className='navigation-icon'>
                                            <SendIcon/>
                                        </ListItemIcon>

                                        <ListItemText inset primary='Users' className='navigation-text'/>

                                    </ListItem>
                                </Link>
                                <Link to={'/doctor-types'} className={ this.isCurrentPath('/doctor-types') ? 'navigation-link active' : 'navigation-link'} >
                                    <ListItem className='navigation-item'>

                                        <ListItemIcon className='navigation-icon'>
                                            <SendIcon/>
                                        </ListItemIcon>

                                        <ListItemText inset primary='Doctor types' className='navigation-text'/>

                                    </ListItem>
                                </Link>
                                <Link to={'/medicines'} className={ this.isCurrentPath('/medicines') ? 'navigation-link active' : 'navigation-link'} >
                                    <ListItem className='navigation-item'>

                                        <ListItemIcon className='navigation-icon'>
                                            <SendIcon/>
                                        </ListItemIcon>

                                        <ListItemText inset primary='Medicines' className='navigation-text'/>

                                    </ListItem>
                                </Link>
                                </React.Fragment>
                        }
                        <React.Fragment>
                            <Link to={'/feedbacks'} className={ this.isCurrentPath('/feedbacks') ? 'navigation-link active' : 'navigation-link'} >
                                <ListItem className='navigation-item'>

                                    <ListItemIcon className='navigation-icon'>
                                        <SendIcon/>
                                    </ListItemIcon>

                                    <ListItemText inset primary='Feedbacks' className='navigation-text'/>

                                </ListItem>
                            </Link>
                            <Link to={'/appointments'} className={ this.isCurrentPath('/appointments') ? 'navigation-link active' : 'navigation-link'} >
                                <ListItem className='navigation-item'>

                                    <ListItemIcon className='navigation-icon'>
                                        <SendIcon/>
                                    </ListItemIcon>

                                    <ListItemText inset primary='Appointments' className='navigation-text'/>

                                </ListItem>
                            </Link>

                            {
                                this.props.auth.user && this.props.auth.user.userType == "DOCTOR" &&
                                <Link to={'/recepies'} className={ this.isCurrentPath('/recepies') ? 'navigation-link active' : 'navigation-link'} >
                                    <ListItem className='navigation-item'>

                                        <ListItemIcon className='navigation-icon'>
                                            <SendIcon/>
                                        </ListItemIcon>

                                        <ListItemText inset primary='Recepies' className='navigation-text'/>

                                    </ListItem>
                                </Link>
                            }

                            
                        </React.Fragment>
                        
                    </List>
                </div>



            </Drawer>
        );
    }
}

function mapDispatchToProps(dispatch)
{
    return bindActionCreators({}, dispatch);
}

function mapStateToProps({ menuReducers, authReducers })
{
    return { menu: menuReducers, auth: authReducers };
}

export default withRouter(connect(mapStateToProps, mapDispatchToProps)(Navigation));