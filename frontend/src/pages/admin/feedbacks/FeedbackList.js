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
import { getFeedbacks, publishFeedback, unpublishFeedback } from '../../../services/FeedbackService';
import AddFeedback from './AddFeedback';


class FeedbackList extends TablePage {

    tableDescription = [
        { key: 'content', label: "Content" },
        { key: 'visible', label: "Published", transform: 'renderColumnDeleted' }
    ];

    constructor(props) {
        super(props);
    }

    fetchData() {

        this.setState({
            lockTable: true
        });

        getFeedbacks({
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
        return <h1>Feedbacks</h1>;
    }

    renderAddContent() {
        return <AddFeedback onCancel={ this.onCancel } onFinish={ this.onFinish }/>
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

    handleBlock(item) {
        publishFeedback(item.id).then(response => {
            this.fetchData();
        })
    }

    handleUnblock(item) {
        unpublishFeedback(item.id).then(response => {
            this.fetchData();
        });
    }

    renderRowMenu(index, item) {

        let ariaOwns = 'action-menu-' + index;
        let userType = this.props.auth.user.userType;
        console.log(userType);

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
                            item.visible && userType == 'ADMIN' &&
                            <MenuItem onClick={ () => this.handleUnblock(item) }>
                                <ListItemIcon>
                                    <UndoIcon/>
                                </ListItemIcon>
                                <ListItemText inset primary="Unpublish"/>
                            </MenuItem>
                        }

{
                            !item.visible && userType == 'ADMIN' &&
                            <MenuItem onClick={ () => this.handleBlock(item) }>
                                <ListItemIcon>
                                    <UndoIcon/>
                                </ListItemIcon>
                                <ListItemText inset primary="Publish"/>
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

export default withSnackbar(withRouter(connect(mapStateToProps, mapDispatchToProps)(FeedbackList)));