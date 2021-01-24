import React from 'react';
import strings from "../../../../localization";
import {getError, hasError} from "../../../../functions/Validation";
import {Button, TextField} from "@material-ui/core";
import SelectControl from '../../../controls/SelectControl';
import DatePickerControl from '../../../controls/DatePickerControl';
import {getUserTypesList} from '../../../../constants/UserType';

const RecepieForm = ({
                      onSubmit,
                      onCancel,
                      onChange,
                      errors,
                      data,
                      medicines,
                      patiens
                  }) => (

    <form id='user-form'>

        <SelectControl
            hasError={ hasError(errors, 'patient') }
            error={ getError(errors, 'patient') }
            options={ patiens }
            selected={ data.patient }
            onChange={ onChange }
            label={ 'Patient' }
            name={ 'patient' }
            nameKey={ 'email' }
            valueKey={ 'id' }
        />

        <SelectControl
            hasError={ hasError(errors, 'medicine') }
            error={ getError(errors, 'medicine') }
            options={ medicines }
            selected={ data.medicine }
            onChange={ onChange }
            label={ 'Medicines' }
            name={ 'medicine' }
            nameKey={ 'name' }
            valueKey={ 'id' }
        />

        <TextField
            label={ "Amount" }
            error={ hasError(errors, 'amount') }
            helperText={ getError(errors, 'amount') }
            fullWidth
            autoFocus
            name='amount'
            onChange={ onChange }
            margin="normal"
            value={ data.amount }
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

export default RecepieForm;