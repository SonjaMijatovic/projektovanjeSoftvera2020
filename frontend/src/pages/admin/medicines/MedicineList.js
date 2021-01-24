import React from 'react'
import TablePage from "../../../common/TablePage";
import {deleteUser, getUsers,} from "../../../services/admin/UserAdminService";
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
import { getMedicines } from '../../../services/MedicineService';
import AddMedicine from './AddMedicine';
import UpdateMedicine from './UpdateMedicine';
import EditIcon from '@material-ui/icons/Edit';


class MedicineList extends TablePage {

    tableDescription = [
        { key: 'name', label: "Name" },
        { key: 'amount', label: "Amount" },
    ];

    constructor(props) {
        super(props);
    }

    fetchData() {

        this.setState({
            lockTable: true
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
        return <h1>Medicines</h1>;
    }

    renderAddContent() {
        return <AddMedicine onCancel={ this.onCancel } onFinish={ this.onFinish }/>
    }

    renderEditContent(item) {
        return <UpdateMedicine data={item} onCancel={ this.onCancel } onFinish={ this.onFinish }/>
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
                            <MenuItem onClick={ () => this.handleMenuEdit(item) }>
                                <ListItemIcon>
                                    <EditIcon/>
                                </ListItemIcon>
                                <ListItemText inset primary={ "Update" }/>
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

export default withSnackbar(withRouter(connect(mapStateToProps, mapDispatchToProps)(MedicineList)));