import React from "react";

const Loading = props => {
    return (
        <div>
            <img src="loading.gif" alt="asd" />
        </div>
    );
};

const NoResultFound = () => {
    return <h2>No Result Found</h2>;
};

export { Loading, NoResultFound };