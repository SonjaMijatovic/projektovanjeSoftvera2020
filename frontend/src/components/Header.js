import React, {Component} from 'react'
import {Link, withRouter} from "react-router-dom";
import {bindActionCreators} from "redux";
import * as Actions from "../actions/Actions";

import connect from "react-redux/es/connect/connect";
import IconButton from '@material-ui/core/IconButton';

import MoreVert from '@material-ui/icons/MoreVert';
import MenuIcon from '@material-ui/icons/Menu';
import PersonIcon from '@material-ui/icons/Person';
import ExitToAppIcon from '@material-ui/icons/ExitToApp';
import LockIcon from '@material-ui/icons/Lock';

import MenuState from "../constants/MenuState";
import {ListItemIcon, ListItemText, Menu, MenuItem} from "@material-ui/core";
import strings from "../localization";
import {lock, logout} from "../base/OAuth";


class Header extends Component {

    constructor(props) {
        super(props);

        this.state = {
            anchorEl: null
        }
    }

    /** HANDLERS **/

    handleMenuClick(event) {
        this.setState({ anchorEl: event.currentTarget });
    }

    handleMenuClose() {
        this.setState({ anchorEl: null });
    }

    logout() {
        logout();
        this.props.logout();
        this.props.history.push('/');
    }

    lock() {
        lock();
        this.props.history.push('/');
    }

    getHeaderClass() {

        if(this.props.menu.state === MenuState.SHORT) {
            return 'short';
        }
        else {
            return '';
        }
    }

    render() {

        return (
            <div id='header' className={ this.getHeaderClass() }>

                <div className='left'>

                    {
                        this.props.menu.state === MenuState.FULL &&
                        <IconButton size='small' onClick={ () => this.props.changeMenuState(MenuState.SHORT) }>
                            <MoreVert/>
                        </IconButton>
                    }

                    {
                        this.props.menu.state === MenuState.SHORT &&
                        <IconButton size='small' onClick={ () => this.props.changeMenuState(MenuState.FULL) }>
                            <MenuIcon/>
                        </IconButton>
                    }

                </div>
                <div className='right'>
                    <IconButton
                        size='small'
                        aria-owns={ this.state.anchorEl ? 'person-menu' : undefined }
                        aria-haspopup="true"
                        onClick={ (event) => this.handleMenuClick(event) }
                    >
                        <PersonIcon/>
                    </IconButton>
                    <Menu
                        id='person-menu'
                        anchorEl={ this.state.anchorEl }
                        open={ Boolean(this.state.anchorEl) }
                        onClose={ () => this.handleMenuClose() }
                    >
                        <MenuItem onClick={ () => this.logout() }>
                            <ListItemIcon>
                                <ExitToAppIcon/>
                            </ListItemIcon>
                            <ListItemText inset primary={ strings.header.logout }/>
                        </MenuItem>
                    </Menu>
                </div>
            </div>

        );
    }
}

function mapDispatchToProps(dispatch)
{
    return bindActionCreators({
        changeMenuState: Actions.changeMenuState,
        logout: Actions.logout,
    }, dispatch);
}

function mapStateToProps({ menuReducers, authReducers })
{
    return { menu: menuReducers, user: authReducers.user };
}

export default withRouter(connect(mapStateToProps, mapDispatchToProps)(Header));