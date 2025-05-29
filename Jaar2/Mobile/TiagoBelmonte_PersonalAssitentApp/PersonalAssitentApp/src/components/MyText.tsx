import { StyleSheet, Text, TextProps, View } from "react-native"; // (dia 108–110) Gebruik van built-in components zoals Text en StyleSheet
import React, { PropsWithChildren } from "react";

type MyTextProps = TextProps & Required<PropsWithChildren>; // (geen directe dia, maar TypeScript good practice)

const MyText = (props: MyTextProps) => {
  return (
    <Text
      {...props}
      style={
        props.style !== undefined && typeof props.style === "object"
          ? { ...styles.container, ...props.style } // (dia 115) Styling combineren met bestaande styles via spread operator
          : styles.container
      }
    >
      {props.children}
    </Text>
  );
};

export default MyText;

const styles = StyleSheet.create({
  container: {
    fontFamily: "DeliusSwashCaps", // (dia 91) Gebruik van custom fonts (Google Fonts)
    color: "blue", // (dia 123–124) Inline styling via StyleSheet objecten, met camelCase notatie
  },
});
