import React from 'react';
import Home from './pages/admin/home/Home';
import Error from "./pages/Error";
import Forbidden from "./pages/Forbidden";
import NotFound from "./pages/NotFound";

import { Route } from 'react-router-dom';
import { isUserLoggedIn } from "./base/OAuth";
import Login from "./pages/user/Login";
import Register from "./pages/user/Register";
import Lock from "./pages/user/Lock";
import UserList from "./pages/admin/users/UserList";
import DoctorTypeList from './pages/admin/doctoreType/DoctorTypeList';
import MedicineList from './pages/admin/medicines/MedicineList';
import FeedbackList from './pages/admin/feedbacks/FeedbackList';
import AppointmentsList from './pages/admin/appointments/AppointmentsList';
import RecepieList from './pages/admin/recepies/RecepieList';

let ROUTES = {
    Home: {
        path: '/',
        component: <Home/>,
        auth: true
    },
    Error: {
        path: '/error',
        component: <Error/>,
        auth: false
    },
    Forbidden: {
        path: '/forbidden',
        component: <Forbidden/>,
        auth: false
    },
    NotFound: {
        path: '/not-found',
        component: <NotFound/>,
        auth: false
    },
    Login: {
        path: '/login',
        component: <Login/>,
        auth: false
    },
    Register: {
        path: '/register',
        component: <Register/>,
        auth: false
    },
    Lock: {
        path: '/lock',
        component: <Lock/>,
        auth: false
    },
    UserList: {
        path: '/users',
        component: <UserList/>,
        auth: true
    },
    DoctorTypesList: {
        path: '/doctor-types',
        component: <DoctorTypeList/>,
        auth: true
    },
    Medicines: {
        path: '/medicines',
        component: <MedicineList/>,
        auth: true
    },
    Feedbacks: {
        path: '/feedbacks',
        component: <FeedbackList/>,
        auth: true
    },
    Appointments: {
        path: '/appointments',
        component: <AppointmentsList/>,
        auth: true
    },
    RecepieList: {
        path: '/recepies',
        component: <RecepieList/>,
        auth: true
    }
};

export default ROUTES;

function getRoute(path) {

    for(const [key, value] of Object.entries(ROUTES)) {

        if(value.path === path) {
            return value;
        }
    }

    return null;
}

export function checkPath(path) {

    let pathObject = getRoute(path);

    if(!pathObject) {
        return true;
    }

    if(pathObject.auth) {
        return !isUserLoggedIn();
    }

    return false;
}

export function getRoutes() {

    let result = [];

    for(const [key, value] of Object.entries(ROUTES)) {

        result.push(
            <Route key={ 'route-' + result.length } exact path={ value.path } render={() => (
                value.component
            )}/>
        )
    }

    return result;
}