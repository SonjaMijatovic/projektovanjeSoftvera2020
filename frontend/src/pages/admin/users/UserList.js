import React from 'react'
import TablePage from "../../../common/TablePage";
import {deleteUser, getUsers, blockUser, unblockUser} from "../../../services/admin/UserAdminService";
import {bindActionCreators} from "redux";
import * as Actions from "../../../actions/Actions";
import {withRouter} from "react-router-dom";
import connect from "react-redux/es/connect/connect";
import strings from "../../../localization";
import AddUser from "./AddUser";
import {withSnackbar} from "notistack";
import {ListItemIcon, ListItemText, Menu, MenuItem, TableCell} from "@material-ui/core";
import IconButton from "@material-ui/core/IconButton";
import MoreVert from '@material-ui/icons/MoreVert';
import UndoIcon from '@material-ui/icons/Undo';
import { getDoctorTypes } from '../../../services/DoctorTypeService';


class UserList extends TablePage {

    tableDescription = [
        { key: 'email', label: strings.userList.email },
        { key: 'firstName', label: strings.userList.firstName },
        { key: 'lastName', label: strings.userList.lastName },
        { key: 'userType', label: "User type" },
        { key: 'doctorType', label: "Doctor Type", transform: 'renderDoctorType' },
        { key: 'blocked', label: "Blocked", transform: 'renderColumnDeleted' }
    ];

    renderDoctorType(item) {
        if(!item) {
            return '';
        }

        return item.name
    }

    constructor(props) {
        super(props);

        this.state.doctoreTypes = [];
    }

    fetchData() {

        this.setState({
            lockTable: true
        });

        getUsers({
            page: this.state.searchData.page,
            perPage: this.state.searchData.perPage,
            search: this.state.searchData.search.toLowerCase()
        }).then(response => {

            if(!response.ok) {
                return;
            }

            this.setState({
                tableData: response.data.entities,
                total: response.data.total,
                lockTable: false
            });
        });

        getDoctorTypes({
            page: this.state.searchData.page,
            perPage: this.state.searchData.perPage,
            search: this.state.searchData.search.toLowerCase()
        }).then(response => {

            if(!response.ok) {
                return;
            }

            this.setState({
                doctoreTypes: response.data.entities ? response.data.entities : [],
                
            });
        });
    }

    componentDidMount() {
        this.fetchData();
    }

    getPageHeader() {
        return <h1>{ strings.userList.pageTitle }</h1>;
    }

    renderAddContent() {
        return <AddUser doctoreTypes={ this.state.doctoreTypes } onCancel={ this.onCancel } onFinish={ this.onFinish }/>
    }

    delete(item) {

        this.setState({
            lockTable: true
        });

        deleteUser(item.id).then(response => {

            if(response && !response.ok) {
                this.onFinish(null);
                return;
            }

            this.props.enqueueSnackbar(strings.userList.userDelete, { variant: 'success' });

            this.onFinish(item);
            this.cancelDelete();

            this.setState({
                lockTable: false
            });
        });
    }

    handleUnblock(item) {
        unblockUser(item.id).then(response => {
            this.fetchData();
        })
    }

    handleBlock(item) {
        blockUser(item.id).then(response => {
            this.fetchData();
        });
    }

    renderRowMenu(index, item) {

        let ariaOwns = 'action-menu-' + index;

        return(
            <TableCell>
                <IconButton
                    aria-owns={ this.state.anchorEl ? ariaOwns : undefined }
                    aria-haspopup="true"
                    onClick={ (event) => this.handleMenuClick(event, ariaOwns) }
                >
                    <MoreVert/>
                </IconButton>
                {
                    ariaOwns === this.state.ariaOwns &&
                    <Menu
                        id={ ariaOwns }
                        anchorEl={ this.state.anchorEl }
                        open={ Boolean(this.state.anchorEl) }
                        onClose={ () => this.handleMenuClose() }
                    >

                        {
                            item.blocked &&
                            <MenuItem onClick={ () => this.handleUnblock(item) }>
                                <ListItemIcon>
                                    <UndoIcon/>
                                </ListItemIcon>
                                <ListItemText inset primary="Unblock"/>
                            </MenuItem>
                        }

{
                            !item.blocked &&
                            <MenuItem onClick={ () => this.handleBlock(item) }>
                                <ListItemIcon>
                                    <UndoIcon/>
                                </ListItemIcon>
                                <ListItemText inset primary="Block"/>
                            </MenuItem>
                        }

                    </Menu>
                }

            </TableCell>
        );
    }
}

function mapDispatchToProps(dispatch)
{
    return bindActionCreators({
        changeFullScreen: Actions.changeFullScreen
    }, dispatch);
}

function mapStateToProps({ menuReducers })
{
    return { menu: menuReducers };
}

export default withSnackbar(withRouter(connect(mapStateToProps, mapDispatchToProps)(UserList)));