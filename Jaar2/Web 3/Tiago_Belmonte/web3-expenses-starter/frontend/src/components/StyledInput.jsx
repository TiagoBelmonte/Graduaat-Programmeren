import React from "react";

const StyledInput = ({ error = true, errorLabel = "Fout", ...restProps }) => {
  return (
    <div className="my-4">
      <input
        {...restProps}
        className={`px-4 py-2 bg-zinc-800 text-gray-300 rounded-lg block w-full text-lg focus:outline-none ${
          error ? "border border-red-600" : ""
        }`}
      />
      {error && (
        <p className="text-red-500 text-sm font-semibold mt-2">{errorLabel}</p>
      )}
    </div>
  );
};

export default StyledInput;
