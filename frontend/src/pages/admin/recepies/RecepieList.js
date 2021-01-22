import React from 'react'
import TablePage from "../../../common/TablePage";
import {deleteUser, getUsers, blockUser, unblockUser} from "../../../services/admin/UserAdminService";
import {bindActionCreators} from "redux";
import * as Actions from "../../../actions/Actions";
import {withRouter} from "react-router-dom";
import connect from "react-redux/es/connect/connect";
import strings from "../../../localization";
import {withSnackbar} from "notistack";
import {ListItemIcon, ListItemText, Menu, MenuItem, TableCell} from "@material-ui/core";
import IconButton from "@material-ui/core/IconButton";
import MoreVert from '@material-ui/icons/MoreVert';
import UndoIcon from '@material-ui/icons/Undo';
import DeleteIcon from '@material-ui/icons/Delete';
import { getDoctorTypes } from '../../../services/DoctorTypeService';
import UserType from '../../../constants/UserType';
import { getMedicines } from '../../../services/MedicineService';
import AddRecepie from './AddRecepie';
import { getRecepies } from '../../../services/RecepieService';


class RecepieList extends TablePage {

    tableDescription = [
        
        { key: 'patient', label: "Patient", transform: 'renderColumnUser' },
        { key: 'medicine', label: "Medicine", transform: 'renderColumnMedicine' },
        { key: 'amount', label: "Amount" }
    ];

    constructor(props) {
        super(props);

        this.state.patiens = [];
        this.state.medicines = [];
    }

    renderColumnMedicine(item) {
        if(!item) 
        {
            return '';
        }

        return item.name;
    }

    renderColumnUser(item) {

        if(!item) 
        {
            return '';
        }

        return item.firstName + " " + item.lastName;
    }

    componentDidMount() {

    }

    fetchData() {

        // this.setState({
        //     lockTable: true
        // });

        getUsers({
            page: this.state.searchData.page,
            perPage: this.state.searchData.perPage,
            search: this.state.searchData.search.toLowerCase()
        }).then(response => {

            if(!response.ok) {
                return;
            }

            let result = [];

            for(let item of response.data.entities) {
                if (item.userType == UserType.PATIENT) {
                    result.push(item);
                }
            }

            this.setState({
                patiens: result,
                
            });
        });

        getMedicines({
            page: this.state.searchData.page,
            perPage: this.state.searchData.perPage,
            search: this.state.searchData.search.toLowerCase()
        }).then(response => {

            if(!response.ok) {
                return;
            }

            this.setState({
                medicines: response.data.entities
            });
        });

        getRecepies({
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
    }

    componentDidMount() {
        this.fetchData();
    }

    getPageHeader() {
        return <h1>Recepies</h1>;
    }

    renderAddContent() {
        return <AddRecepie patiens={ this.state.patiens }
        medicines={ this.state.medicines } onCancel={ this.onCancel } onFinish={ this.onFinish }/>
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
                            !item[this.deletedField] &&
                            <MenuItem onClick={ () => this.handleMenuDelete(item) }>
                                <ListItemIcon>
                                    <DeleteIcon/>
                                </ListItemIcon>
                                <ListItemText inset primary={ strings.table.delete }/>
                            </MenuItem>
                        }
                        {
                            item[this.deletedField] &&
                            <MenuItem onClick={ () => this.handleRestore(item) }>
                                <ListItemIcon>
                                    <UndoIcon/>
                                </ListItemIcon>
                                <ListItemText inset primary={ strings.table.undo }/>
                            </MenuItem>
                        }

                        {
                            !item.isFree &&
                            <MenuItem onClick={ () => this.handleUnblock(item) }>
                                <ListItemIcon>
                                    <UndoIcon/>
                                </ListItemIcon>
                                <ListItemText inset primary="Cancel"/>
                            </MenuItem>
                        }

{
                            item.isFree &&
                            <MenuItem onClick={ () => this.handleBlock(item) }>
                                <ListItemIcon>
                                    <UndoIcon/>
                                </ListItemIcon>
                                <ListItemText inset primary="Reserve"/>
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

function mapStateToProps({ menuReducers, authReducers })
{
    return { menu: menuReducers, auth: authReducers };
}

export default withSnackbar(withRouter(connect(mapStateToProps, mapDispatchToProps)(RecepieList)));