import React from 'react';
import strings from "../../../../localization";
import {getError, hasError} from "../../../../functions/Validation";
import {Button, TextField} from "@material-ui/core";
import SelectControl from '../../../controls/SelectControl';
import DatePickerControl from '../../../controls/DatePickerControl';
import {getUserTypesList} from '../../../../constants/UserType';

const AppointmentForm = ({
                      onSubmit,
                      onCancel,
                      onChange,
                      errors,
                      data,
                      doctors
                  }) => (

    <form id='user-form'>

        <DatePickerControl
            date={data.date}
            name={'date'}
            placeholder={ "Date" }
            onChange={onChange}
        />

        <SelectControl
            hasError={ hasError(errors, 'doctor') }
            error={ getError(errors, 'doctor') }
            options={ doctors }
            selected={ data.doctor }
            onChange={ onChange }
            label={ 'Doctor' }
            name={ 'doctor' }
            nameKey={ 'firstName' }
            valueKey={ 'id' }
        />

        <div className='submit-container'>
            <Button variant="contained" color="primary" onClick={ onSubmit }>
                { strings.userForm.ok }
            </Button>
            <Button variant="contained" color="secondary" onClick={ onCancel }>
                { strings.userForm.cancel }
            </Button>
        </div>
    </form>
);

export default AppointmentForm;