import React from 'react';
import strings from "../../../../localization";
import {getError, hasError} from "../../../../functions/Validation";
import {Button, TextField} from "@material-ui/core";

const MedicineForm = ({
                      onSubmit,
                      onCancel,
                      onChange,
                      errors,
                      data
                  }) => (

    <form id='user-form'>
        <TextField
            label={ "Name" }
            error={ hasError(errors, 'name') }
            helperText={ getError(errors, 'name') }
            fullWidth
            autoFocus
            name='name'
            onChange={ onChange }
            margin="normal"
            value={ data.name }
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
                ok
            </Button>
            <Button variant="contained" color="secondary" onClick={ onCancel }>
                cancel
            </Button>
        </div>
    </form>
);

export default MedicineForm;