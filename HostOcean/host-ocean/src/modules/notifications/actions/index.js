export const displayErrorNotification = (message) =>  enqueueSnackbar({
    message,
    options: {
        variant: 'error',
    },
})

export const displayWarningNotification = (message) =>  enqueueSnackbar({
    message,
    options: {
        variant: 'warning',
    },
})

export const displaySuccessNotification = (message) =>  enqueueSnackbar({
    message,
    options: {
        variant: 'success',
    },
})

export const displayInfoNotification = (message) =>  enqueueSnackbar({
    message,
    options: {
        variant: 'info',
    },
})

export const enqueueSnackbar = notification => ({
    type: 'ENQUEUE_SNACKBAR',
    notification: {
        key: new Date().getTime() + Math.random(),
        ...notification,
    },
});

export const removeSnackbar = key => ({
    type: 'REMOVE_SNACKBAR',
    key,
});