import React from 'react'
import TablePage from "../../../common/TablePage";
import {deleteUser, getUsers, blockUser, unblockUser} from "../../../services/admin/UserAdminService";
import {bindActionCreators} from "redux";
import * as Actions from "../../../actions/Actions";
import {withRouter} from "react-router-dom";
import connect from "react-redux/es/connect/connect";
import strings from "../../../localization";
import {withSnackbar} from "notistack";
import {Button, ListItemIcon, ListItemText, Menu, MenuItem, TableCell} from "@material-ui/core";
import IconButton from "@material-ui/core/IconButton";
import MoreVert from '@material-ui/icons/MoreVert';
import UndoIcon from '@material-ui/icons/Undo';
import DeleteIcon from '@material-ui/icons/Delete';
import { getDoctorTypes } from '../../../services/DoctorTypeService';
import UserType from '../../../constants/UserType';
import { getAppointments, cancelAppointment, reserveAppointment } from '../../../services/AppointmentService';
import AddAppointment from './AddAppointment';
import Grid from '@material-ui/core/Grid';
import Paper from '@material-ui/core/Paper';
import {
 TextField, Drawer
} from "@material-ui/core";
import DrawerWrapper from "../../../common/DrawerWrapper";
import SelectControl from '../../../components/controls/SelectControl';
import DatePickerControl from '../../../components/controls/DatePickerControl';


class AppointmentList extends TablePage {

    tableDescription = [
        { key: 'date', label: "Date" },
        { key: 'doctor', label: "Doctor", transform: 'renderColumnUser' },
        { key: 'patient', label: "Patient", transform: 'renderColumnUser' },
        { key: 'isFree', label: "Is free", transform: 'renderColumnDeleted' }
    ];

    constructor(props) {
        super(props);

        this.state.doctoreTypes = [];

        this.state.showAdd = this.props.auth.user.userType == "ADMIN"
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

            let result = [];

            for(let item of response.data.entities) {
                if (item.userType == UserType.DOCTOR) {
                    result.push(item);
                }
            }

            this.setState({
                doctors: result,
                
            });
        });

        getAppointments({
            page: this.state.searchData.page,
            perPage: this.state.searchData.perPage,
            search: this.state.searchData.search.toLowerCase(),
            doctor: this.state.data.doctor ? this.state.data.doctor.id : -1,
            type: this.state.data.type ? this.state.data.type.value : '',
            from: this.state.data.from ? new Date(this.state.data.from).getTime() : 0,
            to: this.state.data.from ? new Date(this.state.data.to).getTime() : 0
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
        return <h1>Appointments</h1>;
    }

    renderAddContent() {
        return <AddAppointment doctors={ this.state.doctors } onCancel={ this.onCancel } onFinish={ this.onFinish }/>
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
        cancelAppointment(item.id).then(response => {
            this.fetchData();
        })
    }

    handleBlock(item) {
        reserveAppointment(item.id).then(response => {
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

    render() {

        return (
            <Grid id='table-page'>
                { this.renderDialog(strings.table.confirmDelete, 'To subscribe to this website, please enter your email address here. We will send\n' +
                    'updates occasionally.', this.cancelDelete, this.delete) }
                <div className='header'>
                    { this.getPageHeader() }

                    <div className='filter-controls' style={{ display: 'flex',
                flexDirection: 'flex-row', alignItems: 'center' }}>

                    
                            
                            <div style={{ width: '250px' }}>
                                <DatePickerControl
                                    date={this.state.data.from}
                                    name={'from'}
                                    placeholder={ "From" }
                                    onChange={this.changeData}
                                />
                            </div>

                            <div style={{ width: '250px' }}>
                                <DatePickerControl
                                    date={this.state.data.to}
                                    name={'to'}
                                    placeholder={ "To" }
                                    onChange={this.changeData}
                                />
                            </div>
                            
                            <div style={{ width: '150px' }}>
                                <SelectControl
                                    options={ this.state.doctors }
                                    selected={ this.state.data.doctor }
                                    onChange={ this.changeData }
                                    label={ 'Doctor' }
                                    name={ 'doctor' }
                                    nameKey={ 'firstName' }
                                    valueKey={ 'id' }
                                />
                            </div>

                            <div style={{ width: '150px' }}>
                                <SelectControl
                                    options={ [
                                        { value: 'DATE', name: 'Date' },
                                        { value: 'DOCTOR', name: 'Doctor' }
                                    ] }
                                    selected={ this.state.data.type }
                                    onChange={ this.changeData }
                                    label={ 'Type' }
                                    name={ 'type' }
                                    nameKey={ 'name' }
                                    valueKey={ 'value' }
                                />
                            </div>

                            <Button onClick={ () => this.fetchData() } >Find</Button>
                            

                        {
                            this.state.showAdd &&
                            this.renderTableControls()
                        }
                    </div>
                </div>
                <Paper md={12}>
                    { this.renderTable(this.state.tableData) }
                </Paper>

                <Drawer id='drawer' anchor='right' open={  this.showDrawer() } onClose={ () => this.setPageState(PageState.View) } >
                    <DrawerWrapper onBack={ () => this.setPageState(PageState.View) }>
                        { this.renderDrawerContent() }
                    </DrawerWrapper>
                </Drawer>
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

function mapStateToProps({ menuReducers, authReducers })
{
    return { menu: menuReducers, auth: authReducers };
}

export default withSnackbar(withRouter(connect(mapStateToProps, mapDispatchToProps)(AppointmentList)));